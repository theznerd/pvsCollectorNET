using pvsCollectorService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace pvsCollectorService.Helpers
{
    /// <summary>
    /// The FCGIBinder class is responsible for binding the flat JSON data received from the
    /// PVS API to the corresponding C# model classes. It provides methods to bind single
    /// instances of a model class (when the JSON represents a single object) and to bind
    /// multiple instances (when the JSON represents a collection of objects).
    /// </summary>
    public static class FCGIBinder
    {
        private static readonly Regex PropertyParser = new Regex(@"^.*?(?:(?<index>\d+)/)?(?<property>[^/]+)$");

        /// <summary>
        /// Bind a single instance of a model class from the flat JSON data.
        /// </summary>
        /// <typeparam name="T">The PVS Model this flat JSON data represents.</typeparam>
        /// <param name="flatJson">The flat JSON string output by the API.</param>
        /// <returns>A single instance of the type requested.</returns>
        public static T BindSingle<T>(string flatJson) where T : new()
        {
            if (typeof(T) == typeof(PVS6NetStats))
            {
                var properties = ParseAndCleanPVSNetStatsJson(flatJson);
                return MapToInstance<T>(properties);
            }
            else
            {
                var properties = ParseAndCleanJson(flatJson);
                return MapToInstance<T>(properties);
            }
        }

        /// <summary>
        /// Bind a collection of instances of a model class from the flat JSON data.
        /// </summary>
        /// <typeparam name="T">The PVS Model this flat JSON data represents</typeparam>
        /// <param name="flatJson">The flat JSON string output by the API.</param>
        /// <returns>A list of the type requested.</returns>
        public static List<T> BindMany<T>(string flatJson) where T: new()
        {
            using var doc = JsonDocument.Parse(flatJson);
            var groups = new Dictionary<string, Dictionary<string, JsonElement>>();

            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                // Extract the index and property name from the flat JSON key
                var match = PropertyParser.Match(prop.Name);
                if (match.Success)
                {
                    string index = match.Groups["index"].Value;
                    string propertyName = match.Groups["property"].Value;

                    if (!groups.ContainsKey(index)) 
                    {
                        groups[index] = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);
                        if (int.TryParse(index, out int parsedIndex))
                            groups[index]["index"] = JsonSerializer.SerializeToElement(parsedIndex);
                    }
                    groups[index][propertyName] = prop.Value;
                }
            }

            return groups.OrderBy(g => int.Parse(g.Key))
                .Select(g => MapToInstance<T>(g.Value))
                .ToList();
        }

        private static Dictionary<string, JsonElement> ParseAndCleanJson(string flatJson)
        {
            using var doc = JsonDocument.Parse(flatJson);
            var dictionary = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);

            foreach(var prop in doc.RootElement.EnumerateObject())
            {
                var match = PropertyParser.Match(prop.Name);
                if (match.Success)
                {
                    string cleanKey = match.Groups["property"].Value;
                    dictionary[cleanKey] = prop.Value.Clone();
                }
            }
            return dictionary;
        }

        // This method and regex exists because the four network state properties are not in the same
        // format as the other properties, and need to be handled differently.
        private static readonly Regex NetStatsPropertyParser = new Regex(@"^.*/(?<adapter>.*)/.*");
        private static Dictionary<string, JsonElement> ParseAndCleanPVSNetStatsJson(string flatJson)
        {
            using var doc = JsonDocument.Parse(flatJson);
            var dictionary = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);

            foreach(var prop in doc.RootElement.EnumerateObject())
            {
                var match = NetStatsPropertyParser.Match(prop.Name);
                if(match.Success)
                {
                    string cleanKey = match.Groups["adapter"].Value + "_state";
                    dictionary[cleanKey] = prop.Value.Clone();
                }
            }
            return dictionary;
        }

        private static T MapToInstance<T>(Dictionary<string, JsonElement> properties) where T : new()
        {
            var instance = new T();
            var type = typeof(T);

            foreach(var prop in type.GetProperties())
            {
                if(properties.TryGetValue(prop.Name, out var jsonElement))
                {
                    object? value = jsonElement.ValueKind switch
                    {
                        JsonValueKind.String => jsonElement.GetString(),
                        JsonValueKind.Number when prop.PropertyType == typeof(int) => jsonElement.GetInt32(),
                        JsonValueKind.Number when prop.PropertyType == typeof(double) => jsonElement.GetDouble(),
                        JsonValueKind.Number when prop.PropertyType == typeof(float) => jsonElement.GetSingle(),
                        JsonValueKind.Number when prop.PropertyType == typeof(long) => jsonElement.GetInt64(),
                        JsonValueKind.Number when prop.PropertyType == typeof(ulong) => jsonElement.GetUInt64(),
                        JsonValueKind.Number when prop.PropertyType == typeof(uint) => jsonElement.GetUInt32(),
                        JsonValueKind.Number when prop.PropertyType == typeof(short) => jsonElement.GetInt16(),
                        JsonValueKind.Number when prop.PropertyType == typeof(ushort) => jsonElement.GetUInt16(),
                        JsonValueKind.True or JsonValueKind.False => jsonElement.GetBoolean(),
                        _ => null
                    };

                    if(value != null)
                    {
                        prop.SetValue(instance, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }
            return instance;
        }
    }
}

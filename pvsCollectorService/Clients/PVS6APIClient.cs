using pvsCollectorService.Helpers;
using pvsCollectorService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pvsCollectorService.Clients
{
    public class PVS6APIClient
    {
        private readonly HttpClient _httpClient;

        public PVS6APIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #region PVS6 API Calls (Single)
        private bool _essConfigCached = false;
        public async Task<PVS6ESSConfig> GetPVS6ESSConfig(CancellationToken ct)
        {
            string pvs6essconfig;
            if (_essConfigCached != false)
            {
                pvs6essconfig = await _httpClient.GetStringAsync("vars?fmt=obj&cache=essconfig");
            }
            else
            {
                pvs6essconfig = await _httpClient.GetStringAsync("vars?match=/ess/config&fmt=obj&cache=essconfig");
                _essConfigCached = true;
            }
            return FCGIBinder.BindSingle<PVS6ESSConfig>(pvs6essconfig);
        }

        private bool _infoDiagCached = false;
        public async Task<PVS6InfoDiag> GetPVS6InfoDiag(CancellationToken ct)
        {
            string pvs6infodiag;
            if (_infoDiagCached != false) 
            {
                pvs6infodiag = await _httpClient.GetStringAsync("vars?fmt=obj&cache=infodata");
            }
            else
            {
                pvs6infodiag = await _httpClient.GetStringAsync("vars?match=/sys/info&fmt=obj&cache=infodata");
                _infoDiagCached = true;
            }
            
            return FCGIBinder.BindSingle<PVS6InfoDiag>(pvs6infodiag);
        }

        private bool _liveDataCached = false;
        public async Task<PVS6LiveData> GetPVS6LiveData(CancellationToken ct)
        {
            string pvs6livedata;
            if (_liveDataCached != false)
            {
                pvs6livedata = await _httpClient.GetStringAsync("vars?fmt=obj&cache=livedata");
            }
            else
            {
                pvs6livedata = await _httpClient.GetStringAsync("vars?match=/sys/livedata&fmt=obj&cache=livedata");
                _liveDataCached = true;
            }
            return FCGIBinder.BindSingle<PVS6LiveData>(pvs6livedata);
        }

        // Metrics Network doesn't require caching, since we can just call it by direct name (no need to use match)
        public async Task<PVS6MetricsNetwork> GetPVS6MetricsNetwork(CancellationToken ct)
        {
            string pvs6metricsnetwork = await _httpClient.GetStringAsync("vars?name=/metrics/network/interface_report_request&fmt=obj");
            return FCGIBinder.BindSingle<PVS6MetricsNetwork>(pvs6metricsnetwork);
        }

        private bool _netStatsCached = false;
        public async Task<PVS6NetStats> GetPVS6NetStats(CancellationToken ct)
        {
            string pvs6netstats;
            if (_netStatsCached != false)
            {
                pvs6netstats = await _httpClient.GetStringAsync("vars?fmt=obj&cache=netstats");
            }
            else
            {
                pvs6netstats = await _httpClient.GetStringAsync("vars?match=/net/&fmt=obj&cache=netstats");
                _netStatsCached = true;
            }

            return FCGIBinder.BindSingle<PVS6NetStats>(pvs6netstats);
        }

        private bool _netStatsToggleCellCached = false;
        public async Task<PVS6NetStatsToggleCell> GetPVS6NetStatsToggleCell(CancellationToken ct)
        {
            string pvs6netstatstogglecell;
            if (_netStatsToggleCellCached != false)
            {
                pvs6netstatstogglecell = await _httpClient.GetStringAsync("vars?fmt=obj&cache=netstatstogglecell");
            }
            else
            {
                pvs6netstatstogglecell = await _httpClient.GetStringAsync("vars?match=/sys/toggle_cell&fmt=obj&cache=netstatstogglecell");
                _netStatsToggleCellCached = true;
            }
            return FCGIBinder.BindSingle<PVS6NetStatsToggleCell>(pvs6netstatstogglecell);
        }

        private bool _systemStatsCached = false;
        public async Task<PVS6SystemStats> GetPVS6SystemStats(CancellationToken ct)
        {
            string pvs6systemstats;
            if (_systemStatsCached != false)
            {
                pvs6systemstats = await _httpClient.GetStringAsync("vars?fmt=obj&cache=systemstats");
            }
            else
            {
                pvs6systemstats = await _httpClient.GetStringAsync("vars?match=/sys/pvs&fmt=obj&cache=systemstats");
                _systemStatsCached = true;
            }
            return FCGIBinder.BindSingle<PVS6SystemStats>(pvs6systemstats);
        }

        // Telemetry Enabled doesn't require caching, since we can just call it by direct name (no need to use match)
        public async Task<PVS6TelemetryEnable> GetPVS6TelemetryEnable(CancellationToken ct)
        {
            string pvs6telemetryenable = await _httpClient.GetStringAsync("vars?name=/sys/telemetryws/enable&fmt=obj");
            return FCGIBinder.BindSingle<PVS6TelemetryEnable>(pvs6telemetryenable);
        }
        #endregion PVS6 API Calls (Single)

        #region PVS6 API Calls (Many)
        private bool _essDevicesCached = false;
        public async Task<List<PVS6DevicesESS>> GetPVS6DevicesESS(CancellationToken ct)
        {
            string pvs6essdevices;
            if (_essDevicesCached != false)
            {
                pvs6essdevices = await _httpClient.GetStringAsync("vars?fmt=obj&cache=essdevices");
            }
            else
            {
                pvs6essdevices = await _httpClient.GetStringAsync("vars?match=devices/ess&fmt=obj&cache=essdevices");
                _essDevicesCached = true;
            }
            return FCGIBinder.BindMany<PVS6DevicesESS>(pvs6essdevices);
        }

        private bool _inverterDevicesCached = false;
        public async Task<List<PVS6DevicesInverter>> GetPVS6DevicesInverters(CancellationToken ct)
        {
            string pvs6inverterdevices;
            if (_inverterDevicesCached != false)
            {
                pvs6inverterdevices = await _httpClient.GetStringAsync("vars?fmt=obj&cache=inverterdevices");
            }
            else
            {
                pvs6inverterdevices = await _httpClient.GetStringAsync("vars?match=devices/inverter&fmt=obj&cache=inverterdevices");
                _inverterDevicesCached = true;
            }
            return FCGIBinder.BindMany<PVS6DevicesInverter>(pvs6inverterdevices);
        }

        private bool _meterDevicesCached = false;
        public async Task<List<PVS6DevicesMeter>> GetPVS6DevicesMeters(CancellationToken ct)
        {
            string pvs6meterdevices;
            if (_meterDevicesCached != false)
            {
                pvs6meterdevices = await _httpClient.GetStringAsync("vars?fmt=obj&cache=meterdevices");
            }
            else
            {
                pvs6meterdevices = await _httpClient.GetStringAsync("vars?match=devices/meter&fmt=obj&cache=meterdevices");
                _meterDevicesCached = true;
            }
            return FCGIBinder.BindMany<PVS6DevicesMeter>(pvs6meterdevices);
        }

        private bool _trasnferSwitchDevicesCached = false;
        public async Task<List<PVS6DevicesTransferSwitch>> GetPVS6DevicesTransferSwitches(CancellationToken ct)
        {
            string pvs6transferswitchdevices;
            if (_trasnferSwitchDevicesCached != false)
            {
                pvs6transferswitchdevices = await _httpClient.GetStringAsync("vars?fmt=obj&cache=transferswitchdevices");
            }
            else
            {
                pvs6transferswitchdevices = await _httpClient.GetStringAsync("vars?match=devices/transfer_switch&fmt=obj&cache=transferswitchdevices");
            }
            return FCGIBinder.BindMany<PVS6DevicesTransferSwitch>(pvs6transferswitchdevices);
        }
        #endregion PVS API Calls (Many)
    }
}
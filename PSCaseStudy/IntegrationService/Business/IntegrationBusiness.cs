using IntegrationService.Services;
using PSCaseStudy.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationService.Business
{
    public class IntegrationBusiness
    {
        private IntegrationDataService _dataService;
        public IntegrationBusiness()
        {
            _dataService = new IntegrationDataService();
        }
        public async Task<(bool, string)> SendData(IntegrationItem item)
        {
            return await _dataService.SendDataAsync(item);
        }
        public List<IntegrationItem> GetTopNRows(int n = 100)
        {
            return _dataService.GetTopNRows(n);
        }
    }
}

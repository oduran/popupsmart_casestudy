using IntegrationService.Data;
using IntegrationService.Datas.Enums;
using IntegrationService.Extensions;
using IntegrationService.Helpers;
using IntegrationService.Items;
using PSCaseStudy.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationService.Services
{
    public class IntegrationDataService
    {
        public List<IntegrationItem> GetTopNRows(int n = 100)
        {
            var list = new List<IntegrationItem>();

            using (var context = new AppDbContext())
            {
                try
                {
                    list = context.IntegrationItems.Where(x => x.Status == (int)IntegrationStatusEnum.NotSent).Take(n).ToList();
                }
                catch (Exception ex)
                {
                    return Enumerable.Empty<IntegrationItem>().ToList();
                }
            }

            return list;
        }

        // Datayı gönderir başarılı/başarısız durumuna göre güncellenir.
        public async Task<(bool, string)> SendDataAsync(IntegrationItem item)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var oRow = context.IntegrationItems.Where(a => a.Id == item.Id).FirstOrDefault();
                    if (oRow == null)
                        return (false, string.Empty);
                    
                    var serverConfigs = ConfigurationHelper.GetServerConfigs();
                    var postData = JsonSerializer.Serialize(oRow);
                    switch (oRow.IntegrationApplication)
                    {
                        case PSCaseStudy.Datas.Enums.IntegrationApplicationEnum.EmailOctopus:
                            await APIHelper.Instance.Post(serverConfigs.ServerUrl, postData);
                            break;
                        case PSCaseStudy.Datas.Enums.IntegrationApplicationEnum.ActiveCampaign:
                            var res2 = await APIHelper.Instance.GetActiveCampaignData(serverConfigs.ServerUrl, oRow);
                            var res3 = await APIHelper.Instance.Post($"{serverConfigs.ServerUrl}/contact/addactivecampaignitem/{oRow.Id}", (string)res2.Data);
                            break;
                        default:
                            break;
                    }
                    if(oRow.IntegrationApplication == PSCaseStudy.Datas.Enums.IntegrationApplicationEnum.ActiveCampaign) { }
                    var res = await APIHelper.Instance.Post(serverConfigs.ServerUrl,postData);

                    if (res.IsOk)
                    {
                        oRow.Status = (PSCaseStudy.Datas.Enums.IntegrationStatusEnum)IntegrationStatusEnum.Success;
                    }
                    else
                    {
                        oRow.Status = (PSCaseStudy.Datas.Enums.IntegrationStatusEnum)IntegrationStatusEnum.Fail;
                    }

                    context.SaveChanges();
                }
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}


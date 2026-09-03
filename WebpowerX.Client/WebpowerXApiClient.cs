using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebpowerX.Client.Internal;
using WebpowerX.Client.Models;

namespace WebpowerX.Client
{
    /// <summary>
    /// WebpowerX 客户端的主入口实现。
    /// </summary>
    public sealed class WebpowerXApiClient : IWebpowerXApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly WebpowerXApiOptions _options;

        /// <summary>
        /// 初始化 <see cref="WebpowerXApiClient" /> 的新实例。
        /// </summary>
        /// <param name="httpClient">由 <see cref="IHttpClientFactory" /> 通过 <c>AddHttpClient</c> 创建的客户端。</param>
        /// <param name="options">接口基础配置。</param>
        public WebpowerXApiClient(HttpClient httpClient, IOptions<WebpowerXApiOptions> options)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));

            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(NormalizeBaseUrl(_options.BaseUrl));
            }

            if (_httpClient.DefaultRequestHeaders.Accept.Count == 0)
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        #region 邮件发送接口

        /// <summary>
        /// 调用单封事务邮件发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendSingleTransactionalEmailAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/transactional/sendSingleEmail", request, cancellationToken);

        /// <summary>
        /// 调用单封普通邮件发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendSingleEmailAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/sendSingleEmail", request, cancellationToken);

        /// <summary>
        /// 调用批量普通邮件发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendBulkEmailsAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/sendBulkEmails", request, cancellationToken);

        /// <summary>
        /// 调用个性化发送任务创建接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreatePersonalizedTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskCreationResult>("iemail-send/open-api/v2/send-task/createPersonalizedTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板发送任务创建接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateTemplateTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskCreationResult>("iemail-send/open-api/v2/send-task/createTemplateTask", request, cancellationToken);

        /// <summary>
        /// 调用个性化任务内发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinPersonalizedTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/sendWithinPersonalizedTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板任务单封发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinTemplateTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/sendWithinTemplateTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板任务批量发送接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinTemplateTaskToEmailsAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskResponse>("iemail-send/open-api/v2/send/sendWithinTemplateTaskToEmails", request, cancellationToken);

        /// <summary>
        /// 调用云文件自定义内容任务创建接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateCloudFileRecipientTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskCreationResult>("iemail-send/open-api/v2/send-task/createCloudFileRecipientTask", request, cancellationToken);

        /// <summary>
        /// 调用云文件素材任务创建接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateCloudFileRecipientTaskFromMaterialAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXSendTaskCreationResult>("iemail-send/open-api/v2/send-task/createCloudFileRecipientTask/fromMaterial", request, cancellationToken);

        #endregion

        #region 发件基础配置

        /// <summary>
        /// 调用获取发件域名接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXDomainInfo>>> GetDomainAsync(string domain, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXDomainInfo>>("openapi/open-api/v1/email/getDomain", new { domain }, cancellationToken);

        /// <summary>
        /// 调用获取发件域名邮件通道接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXEmailRouteInfo>>> GetEmailRouteOverDomainAsync(string domain, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXEmailRouteInfo>>("openapi/open-api/v1/email/getEmailRouteOverDomain", new { domain }, cancellationToken);

        /// <summary>
        /// 调用创建发件地址接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>> CreateSenderAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>("openapi/open-api/v1/email/createSender", request, cancellationToken);

        /// <summary>
        /// 调用获取发件地址接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>> GetSenderAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>("openapi/open-api/v1/email/getSender", request, cancellationToken);

        /// <summary>
        /// 调用获取回复地址接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXReplyAddressInfo>>> GetReplyAddressAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXReplyAddressInfo>>("openapi/open-api/v1/email/getReplyAddress", request, cancellationToken);

        /// <summary>
        /// 调用新增或更新回复地址接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> SaveOrUpdateReplyAddressAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/email/saveOrUpdateReplyAddress", request, cancellationToken);

        #endregion

        #region 联系人管理

        /// <summary>
        /// 调用联系人分页列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactInfo>>> ContactPageListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXPagedResponse<WebpowerXContactInfo>>("openapi/open-api/v1/contact/contactPageList", request, cancellationToken);

        /// <summary>
        /// 调用联系人属性接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXContactAttributeValue>>> ContactCustomerDetailsAsync(object request, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXContactAttributeValue>>("openapi/open-api/v1/contact/contactCustomerDetails", request, cancellationToken);

        /// <summary>
        /// 调用联系人字段详情接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXContactFieldDetail>>> ContactFieldDetailsAsync(object request, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXContactFieldDetail>>("openapi/open-api/v1/contact/contactFieldDetails", request, cancellationToken);

        /// <summary>
        /// 调用联系人标签列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXContactLabelListResponse>> ContactLabelListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXContactLabelListResponse>("openapi/open-api/v1/contact/contactLabelList", request, cancellationToken);

        /// <summary>
        /// 调用标签下联系人分页接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactInfo>>> ContactByLabelPageListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXPagedResponse<WebpowerXContactInfo>>("openapi/open-api/v1/contact/contactByLabelPageList", request, cancellationToken);

        #endregion

        #region 联系人属性管理

        /// <summary>
        /// 调用创建联系人属性接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXContactFieldUpsertResult>> CreateContactFieldAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXContactFieldUpsertResult>("openapi/open-api/v1/contact/createContactField", request, cancellationToken);

        /// <summary>
        /// 调用更新联系人属性接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> EditContactFieldAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/editContactField", request, cancellationToken);

        /// <summary>
        /// 调用删除联系人属性接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteContactFieldAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/deleteContactField", request, cancellationToken);

        /// <summary>
        /// 调用联系人属性列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactFieldInfo>>> FindContactFieldAsync(object request, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXPagedResponse<WebpowerXContactFieldInfo>>("openapi/open-api/v1/contact/findContactField", request, cancellationToken);

        #endregion

        #region 标签管理

        /// <summary>
        /// 调用创建标签接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXLabelUpsertResult>> CreateLabelAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXLabelUpsertResult>("openapi/open-api/v1/contact/createLabel", request, cancellationToken);

        /// <summary>
        /// 调用编辑标签接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXLabelUpsertResult>> EditLabelAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXLabelUpsertResult>("openapi/open-api/v1/contact/editLabel", request, cancellationToken);

        /// <summary>
        /// 调用删除标签接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteLabelAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/deleteLabel", request, cancellationToken);

        /// <summary>
        /// 调用标签分页列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXLabelInfo>>> LabelPageListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXPagedResponse<WebpowerXLabelInfo>>("openapi/open-api/v1/contact/labelPageList", request, cancellationToken);

        /// <summary>
        /// 调用标签分组列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXLabelGroupInfo>>> LabelGroupListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXLabelGroupInfo>>("openapi/open-api/v1/contact/labelGroupList", request, cancellationToken);

        /// <summary>
        /// 调用创建标签分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXLabelGroupUpsertResult>> CreateLabelGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXLabelGroupUpsertResult>("openapi/open-api/v1/contact/createLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用编辑标签分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXLabelGroupUpsertResult>> EditLabelGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXLabelGroupUpsertResult>("openapi/open-api/v1/contact/editLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用删除标签分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteLabelGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/deleteLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用更改联系人标签接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> ChangeCustomerLabelAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/ChangeCustomerLabel", request, cancellationToken);

        /// <summary>
        /// 调用添加标签到联系人接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXCustomerLabelAddResult>>> SaveCustomerLabelAndAddAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXResultListResponse<WebpowerXCustomerLabelAddResult>>("openapi/open-api/v1/contact/saveCustomerLabelAndAdd", request, cancellationToken);

        /// <summary>
        /// 调用删除联系人的标签接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteCustomerLabelAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/contact/deleteCustomerLabel", request, cancellationToken);

        #endregion

        #region 内容素材管理

        /// <summary>
        /// 调用素材分组列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXMaterialGroupInfo>>> GroupListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXResultListResponse<WebpowerXMaterialGroupInfo>>("openapi/open-api/v1/material/groupList", request, cancellationToken);

        /// <summary>
        /// 调用创建素材分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXMaterialGroupUpsertResult>> CreateMaterialGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXMaterialGroupUpsertResult>("openapi/open-api/v1/material/createMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用编辑素材分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXMaterialGroupUpsertResult>> EditMaterialGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXMaterialGroupUpsertResult>("openapi/open-api/v1/material/editMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用删除素材分组接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteMaterialGroupAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/material/deleteMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用邮件素材分页列表接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXMaterialInfo>>> EmailMaterialPageListAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXPagedResponse<WebpowerXMaterialInfo>>("openapi/open-api/v1/material/emailMaterialPageList", request, cancellationToken);

        /// <summary>
        /// 调用邮件素材详情接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXMaterialDetails>> EmailMaterialDetailsAsync(object request, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXMaterialDetails>("openapi/open-api/v1/material/emailMaterialDetails", request, cancellationToken);

        /// <summary>
        /// 调用创建邮件素材接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXMaterialUpsertResult>> CreateMaterialAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXMaterialUpsertResult>("openapi/open-api/v1/material/createMaterial", request, cancellationToken);

        /// <summary>
        /// 调用编辑邮件素材接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXMaterialUpsertResult>> EditMaterialAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXMaterialUpsertResult>("openapi/open-api/v1/material/editMaterial", request, cancellationToken);

        /// <summary>
        /// 调用删除邮件素材接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteMaterialAsync(object request, CancellationToken cancellationToken = default)
            => SendJsonAsync<WebpowerXEmptyResult>("openapi/open-api/v1/material/deleteMaterial", request, cancellationToken);

        #endregion

        #region 数据统计

        /// <summary>
        /// 调用邮件报告接口。
        /// </summary>
        public Task<WebpowerXApiResponse<WebpowerXEmailReport>> GetEmailReportAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<WebpowerXEmailReport>("openapi/open-api/v1/iEmailCallback/getEmailReport", request, cancellationToken);

        /// <summary>
        /// 调用事件记录查询接口。
        /// </summary>
        public Task<WebpowerXApiResponse<List<WebpowerXEmailEventRecord>>> GetStatisticsDataTypeAsync(object? request = null, CancellationToken cancellationToken = default)
            => GetAsync<List<WebpowerXEmailEventRecord>>("openapi/open-api/v1/iEmailCallback/getStatisticsDataType", request, cancellationToken);

        #endregion

        /// <summary>
        /// 发送 JSON 请求。
        /// </summary>
        private Task<WebpowerXApiResponse<TResponse>> SendJsonAsync<TResponse>(string path, object body, CancellationToken cancellationToken = default)
            => SendAsync<TResponse>(path, HttpMethod.Post, body, null, cancellationToken);

        /// <summary>
        /// 发送请求并反序列化响应。
        /// </summary>
        private async Task<WebpowerXApiResponse<TResponse>> SendAsync<TResponse>(string path, HttpMethod method, object? body, object? query, CancellationToken cancellationToken)
        {
            var accessSign = WebpowerXSignatureGenerator.Generate(_options.AccessKeySecret);
            var requestUri = query != null ? path + BuildQueryString(query) : path;

            using var request = new HttpRequestMessage(method, requestUri);
            request.Headers.TryAddWithoutValidation("access-key", _options.AccessKey);
            request.Headers.TryAddWithoutValidation("access-sign", accessSign);

            if (body != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(body, JsonDefaults.Options), Encoding.UTF8, "application/json");
            }

            using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new WebpowerXApiRequestException($"HTTP {(int)response.StatusCode} from WebpowerX API: {content}");
            }

            var envelope = JsonSerializer.Deserialize<WebpowerXApiResponse<TResponse>>(content, JsonDefaults.Options)
                ?? throw new WebpowerXApiRequestException("Failed to deserialize WebpowerX API response.");

            if (!envelope.IsSuccess)
            {
                throw new WebpowerXApiException(envelope.Code, envelope.Message, envelope.ResponseId, envelope.TraceNumber);
            }

            return envelope;
        }

        /// <summary>
        /// 发送 GET 请求并反序列化响应。
        /// </summary>
        private Task<WebpowerXApiResponse<TResponse>> GetAsync<TResponse>(string path, object? query, CancellationToken cancellationToken)
            => SendAsync<TResponse>(path, HttpMethod.Get, null, query, cancellationToken);

        /// <summary>
        /// 生成查询字符串。
        /// </summary>
        private static string BuildQueryString(object query)
        {
            var pairs = new List<string>();

            if (query is IEnumerable<KeyValuePair<string, object>> dictObject)
            {
                foreach (var pair in dictObject)
                {
                    AppendPair(pairs, pair.Key, pair.Value);
                }
            }
            else if (query is IEnumerable<KeyValuePair<string, object?>> dictNullable)
            {
                foreach (var pair in dictNullable)
                {
                    AppendPair(pairs, pair.Key, pair.Value);
                }
            }
            else
            {
                var props = query.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                for (var i = 0; i < props.Length; i++)
                {
                    var prop = props[i];
                    if (!prop.CanRead)
                    {
                        continue;
                    }

                    AppendPair(pairs, prop.Name, prop.GetValue(query, null));
                }
            }

            return pairs.Count == 0 ? string.Empty : "?" + string.Join("&", pairs);
        }

        /// <summary>
        /// 添加查询字符串键值对。
        /// </summary>
        private static void AppendPair(ICollection<string> pairs, string key, object? value)
        {
            if (value == null)
            {
                return;
            }

            var text = Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            pairs.Add(Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(text));
        }

        /// <summary>
        /// 保证 BaseUrl 以 / 结尾，方便后续拼接相对路径。
        /// </summary>
        private static string NormalizeBaseUrl(string baseUrl)
            => baseUrl.EndsWith("/", StringComparison.Ordinal) ? baseUrl : baseUrl + "/";
    }
}

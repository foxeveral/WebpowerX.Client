using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        /// <summary>
        /// 查询参数定义缓存。
        /// </summary>
        private static readonly ConcurrentDictionary<Type, QueryParameter[]> QueryParameterCache = new ConcurrentDictionary<Type, QueryParameter[]>();

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
                _httpClient.BaseAddress = new Uri(UrlHelper.NormalizeBaseUrl(_options.BaseUrl));
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
        public Task<ApiResponse<SendResult>> SendSingleTransactionalEmailAsync(SingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/transactional/sendSingleEmail", request, cancellationToken);

        /// <summary>
        /// 调用单封普通邮件发送接口。
        /// </summary>
        public Task<ApiResponse<SendResult>> SendSingleEmailAsync(SingleEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/sendSingleEmail", request, cancellationToken);

        /// <summary>
        /// 调用批量普通邮件发送接口。
        /// </summary>
        public Task<ApiResponse<SendResult>> SendBulkEmailsAsync(BulkEmailRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/sendBulkEmails", request, cancellationToken);

        /// <summary>
        /// 调用个性化发送任务创建接口。
        /// </summary>
        public Task<ApiResponse<SendTaskCreateResult>> CreatePersonalizedTaskAsync(CreatePersonalizedTaskRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendTaskCreateResult>("iemail-send/open-api/v2/send-task/createPersonalizedTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板发送任务创建接口。
        /// </summary>
        public Task<ApiResponse<SendTaskCreateResult>> CreateTemplateTaskAsync(CreateTemplateTaskRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendTaskCreateResult>("iemail-send/open-api/v2/send-task/createTemplateTask", request, cancellationToken);

        /// <summary>
        /// 调用个性化任务内发送接口。
        /// </summary>
        public Task<ApiResponse<SendResult>> SendWithinPersonalizedTaskAsync(SendWithinPersonalizedTaskRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/sendWithinPersonalizedTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板任务单封发送接口。
        /// </summary>
        public Task<ApiResponse<SendResult>> SendWithinTemplateTaskAsync(SendWithinTemplateTaskRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/sendWithinTemplateTask", request, cancellationToken);

        /// <summary>
        /// 调用固定模板任务批量发送接口。
        /// </summary>
        public Task<ApiResponse<SendResult>> SendWithinTemplateTaskToEmailsAsync(SendWithinTemplateTaskToEmailsRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendResult>("iemail-send/open-api/v2/send/sendWithinTemplateTaskToEmails", request, cancellationToken);

        /// <summary>
        /// 调用云文件自定义内容任务创建接口。
        /// </summary>
        public Task<ApiResponse<SendTaskCreateResult>> CreateCloudFileRecipientTaskAsync(CreateCloudFileTaskRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendTaskCreateResult>("iemail-send/open-api/v2/send-task/createCloudFileRecipientTask", request, cancellationToken);

        /// <summary>
        /// 调用云文件素材任务创建接口。
        /// </summary>
        public Task<ApiResponse<SendTaskCreateResult>> CreateCloudFileRecipientTaskFromMaterialAsync(CreateCloudFileTaskFromMaterialRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<SendTaskCreateResult>("iemail-send/open-api/v2/send-task/createCloudFileRecipientTask/fromMaterial", request, cancellationToken);

        #endregion

        #region 发件基础配置

        /// <summary>
        /// 调用获取发件域名接口。
        /// </summary>
        public Task<ApiResponse<ResultList<DomainInfo>>> GetDomainAsync(DomainQuery request, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<DomainInfo>>("openapi/open-api/v1/email/getDomain", request, cancellationToken);

        /// <summary>
        /// 调用获取发件域名邮件通道接口。
        /// </summary>
        public Task<ApiResponse<ResultList<EmailRouteInfo>>> GetEmailRouteOverDomainAsync(EmailRouteOverDomainQuery request, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<EmailRouteInfo>>("openapi/open-api/v1/email/getEmailRouteOverDomain", request, cancellationToken);

        /// <summary>
        /// 调用创建发件地址接口。
        /// </summary>
        public Task<ApiResponse<ResultList<SenderAddressInfo>>> CreateSenderAsync(CreateSenderRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<ResultList<SenderAddressInfo>>("openapi/open-api/v1/email/createSender", request, cancellationToken);

        /// <summary>
        /// 调用获取发件地址接口。
        /// </summary>
        public Task<ApiResponse<ResultList<SenderAddressInfo>>> GetSenderAsync(SenderQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<SenderAddressInfo>>("openapi/open-api/v1/email/getSender", request, cancellationToken);

        /// <summary>
        /// 调用获取回复地址接口。
        /// </summary>
        public Task<ApiResponse<ResultList<ReplyAddressInfo>>> GetReplyAddressAsync(ReplyAddressQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<ReplyAddressInfo>>("openapi/open-api/v1/email/getReplyAddress", request, cancellationToken);

        /// <summary>
        /// 调用新增或更新回复地址接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> SaveOrUpdateReplyAddressAsync(SaveOrUpdateReplyAddressRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<EmptyResult>("openapi/open-api/v1/email/saveOrUpdateReplyAddress", request, cancellationToken);

        #endregion

        #region 联系人管理

        /// <summary>
        /// 调用联系人分页列表接口。
        /// </summary>
        public Task<ApiResponse<PagedResult<ContactInfo>>> ContactPageListAsync(ContactPageListQuery request, CancellationToken cancellationToken = default)
            => GetAsync<PagedResult<ContactInfo>>("openapi/open-api/v1/contact/contactPageList", request, cancellationToken);

        /// <summary>
        /// 调用联系人属性接口。
        /// </summary>
        public Task<ApiResponse<ResultList<ContactAttributeValue>>> ContactCustomerDetailsAsync(ContactIdentityQuery request, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<ContactAttributeValue>>("openapi/open-api/v1/contact/contactCustomerDetails", request, cancellationToken);

        /// <summary>
        /// 调用联系人字段详情接口。
        /// </summary>
        public Task<ApiResponse<ResultList<ContactFieldDetail>>> ContactFieldDetailsAsync(CancellationToken cancellationToken = default)
            => GetAsync<ResultList<ContactFieldDetail>>("openapi/open-api/v1/contact/contactFieldDetails", null, cancellationToken);

        /// <summary>
        /// 调用联系人标签列表接口。
        /// </summary>
        public Task<ApiResponse<ContactLabelListResult>> ContactLabelListAsync(ContactIdentityQuery request, CancellationToken cancellationToken = default)
            => GetAsync<ContactLabelListResult>("openapi/open-api/v1/contact/contactLabelList", request, cancellationToken);

        /// <summary>
        /// 调用标签下联系人分页接口。
        /// </summary>
        public Task<ApiResponse<PagedResult<ContactInfo>>> ContactByLabelPageListAsync(ContactByLabelPageQuery request, CancellationToken cancellationToken = default)
            => GetAsync<PagedResult<ContactInfo>>("openapi/open-api/v1/contact/contactByLabelPageList", request, cancellationToken);

        #endregion

        #region 联系人属性管理

        /// <summary>
        /// 调用创建联系人属性接口。
        /// </summary>
        public Task<ApiResponse<ContactFieldUpsertResult>> CreateContactFieldAsync(CreateContactFieldRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<ContactFieldUpsertResult>("openapi/open-api/v1/contact/createContactField", request, cancellationToken);

        /// <summary>
        /// 调用更新联系人属性接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> EditContactFieldAsync(EditContactFieldRequest request, CancellationToken cancellationToken = default)
            => PutJsonAsync<EmptyResult>("openapi/open-api/v1/contact/editContactField", request, cancellationToken);

        /// <summary>
        /// 调用删除联系人属性接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteContactFieldAsync(DeleteContactFieldQuery request, CancellationToken cancellationToken = default)
            => DeleteAsync<EmptyResult>("openapi/open-api/v1/contact/deleteContactField", request, cancellationToken);

        /// <summary>
        /// 调用联系人属性列表接口。
        /// </summary>
        public Task<ApiResponse<PagedResult<ContactFieldInfo>>> FindContactFieldAsync(ContactFieldPageQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<PagedResult<ContactFieldInfo>>("openapi/open-api/v1/contact/findContactField", request, cancellationToken);

        #endregion

        #region 标签管理

        /// <summary>
        /// 调用创建标签接口。
        /// </summary>
        public Task<ApiResponse<LabelUpsertResult>> CreateLabelAsync(CreateLabelRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<LabelUpsertResult>("openapi/open-api/v1/contact/createLabel", request, cancellationToken);

        /// <summary>
        /// 调用编辑标签接口。
        /// </summary>
        public Task<ApiResponse<LabelUpsertResult>> EditLabelAsync(EditLabelRequest request, CancellationToken cancellationToken = default)
            => PutJsonAsync<LabelUpsertResult>("openapi/open-api/v1/contact/editLabel", request, cancellationToken);

        /// <summary>
        /// 调用删除标签接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteLabelAsync(DeleteLabelsRequest request, CancellationToken cancellationToken = default)
            => DeleteJsonAsync<EmptyResult>("openapi/open-api/v1/contact/deleteLabel", request, cancellationToken);

        /// <summary>
        /// 调用标签分页列表接口。
        /// </summary>
        public Task<ApiResponse<PagedResult<LabelInfo>>> LabelPageListAsync(LabelPageQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<PagedResult<LabelInfo>>("openapi/open-api/v1/contact/labelPageList", request, cancellationToken);

        /// <summary>
        /// 调用标签分组列表接口。
        /// </summary>
        public Task<ApiResponse<ResultList<LabelGroupInfo>>> LabelGroupListAsync(LabelGroupListQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<LabelGroupInfo>>("openapi/open-api/v1/contact/labelGroupList", request, cancellationToken);

        /// <summary>
        /// 调用创建标签分组接口。
        /// </summary>
        public Task<ApiResponse<LabelGroupUpsertResult>> CreateLabelGroupAsync(CreateLabelGroupRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<LabelGroupUpsertResult>("openapi/open-api/v1/contact/createLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用编辑标签分组接口。
        /// </summary>
        public Task<ApiResponse<LabelGroupUpsertResult>> EditLabelGroupAsync(EditLabelGroupRequest request, CancellationToken cancellationToken = default)
            => PutJsonAsync<LabelGroupUpsertResult>("openapi/open-api/v1/contact/editLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用删除标签分组接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteLabelGroupAsync(DeleteLabelGroupQuery request, CancellationToken cancellationToken = default)
            => DeleteAsync<EmptyResult>("openapi/open-api/v1/contact/deleteLabelGroup", request, cancellationToken);

        /// <summary>
        /// 调用更改联系人标签接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> ChangeCustomerLabelAsync(ChangeCustomerLabelRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<EmptyResult>("openapi/open-api/v1/contact/ChangeCustomerLabel", request, cancellationToken);

        /// <summary>
        /// 调用添加标签到联系人接口。
        /// </summary>
        public Task<ApiResponse<ResultList<CustomerLabelAddResult>>> SaveCustomerLabelAndAddAsync(SaveCustomerLabelAndAddRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<ResultList<CustomerLabelAddResult>>("openapi/open-api/v1/contact/saveCustomerLabelAndAdd", request, cancellationToken);

        /// <summary>
        /// 调用删除联系人的标签接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteCustomerLabelAsync(DeleteCustomerLabelQuery request, CancellationToken cancellationToken = default)
            => DeleteAsync<EmptyResult>("openapi/open-api/v1/contact/deleteCustomerLabel", request, cancellationToken);

        #endregion

        #region 内容素材管理

        /// <summary>
        /// 调用素材分组列表接口。
        /// </summary>
        public Task<ApiResponse<ResultList<MaterialGroupInfo>>> GroupListAsync(MaterialGroupListQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<ResultList<MaterialGroupInfo>>("openapi/open-api/v1/material/groupList", request, cancellationToken);

        /// <summary>
        /// 调用创建素材分组接口。
        /// </summary>
        public Task<ApiResponse<MaterialGroupUpsertResult>> CreateMaterialGroupAsync(CreateMaterialGroupRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<MaterialGroupUpsertResult>("openapi/open-api/v1/material/createMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用编辑素材分组接口。
        /// </summary>
        public Task<ApiResponse<MaterialGroupUpsertResult>> EditMaterialGroupAsync(EditMaterialGroupRequest request, CancellationToken cancellationToken = default)
            => PutJsonAsync<MaterialGroupUpsertResult>("openapi/open-api/v1/material/editMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用删除素材分组接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteMaterialGroupAsync(DeleteMaterialGroupQuery request, CancellationToken cancellationToken = default)
            => DeleteAsync<EmptyResult>("openapi/open-api/v1/material/deleteMaterialGroup", request, cancellationToken);

        /// <summary>
        /// 调用邮件素材分页列表接口。
        /// </summary>
        public Task<ApiResponse<PagedResult<MaterialInfo>>> EmailMaterialPageListAsync(EmailMaterialPageQuery? request = null, CancellationToken cancellationToken = default)
            => GetAsync<PagedResult<MaterialInfo>>("openapi/open-api/v1/material/emailMaterialPageList", request, cancellationToken);

        /// <summary>
        /// 调用邮件素材详情接口。
        /// </summary>
        public Task<ApiResponse<MaterialDetails>> EmailMaterialDetailsAsync(MaterialSnQuery request, CancellationToken cancellationToken = default)
            => GetAsync<MaterialDetails>("openapi/open-api/v1/material/emailMaterialDetails", request, cancellationToken);

        /// <summary>
        /// 调用创建邮件素材接口。
        /// </summary>
        public Task<ApiResponse<MaterialUpsertResult>> CreateMaterialAsync(CreateMaterialRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<MaterialUpsertResult>("openapi/open-api/v1/material/createMaterial", request, cancellationToken);

        /// <summary>
        /// 调用编辑邮件素材接口。
        /// </summary>
        public Task<ApiResponse<MaterialUpsertResult>> EditMaterialAsync(EditMaterialRequest request, CancellationToken cancellationToken = default)
            => PutJsonAsync<MaterialUpsertResult>("openapi/open-api/v1/material/editMaterial", request, cancellationToken);

        /// <summary>
        /// 调用删除邮件素材接口。
        /// </summary>
        public Task<ApiResponse<EmptyResult>> DeleteMaterialAsync(MaterialSnQuery request, CancellationToken cancellationToken = default)
            => DeleteAsync<EmptyResult>("openapi/open-api/v1/material/deleteMaterial", request, cancellationToken);

        #endregion

        #region 数据统计

        /// <summary>
        /// 调用邮件报告接口。
        /// </summary>
        public Task<ApiResponse<EmailReport>> GetEmailReportAsync(EmailReportRequest request, CancellationToken cancellationToken = default)
            => SendJsonAsync<EmailReport>("openapi/open-api/v1/iEmailCallback/getEmailReport", request, cancellationToken);

        /// <summary>
        /// 调用事件记录查询接口。
        /// </summary>
        public Task<ApiResponse<List<EmailEventRecord>>> GetStatisticsDataTypeAsync(EventRecordQuery request, CancellationToken cancellationToken = default)
            => SendJsonAsync<List<EmailEventRecord>>("openapi/open-api/v1/iEmailCallback/getStatisticsDataType", request, cancellationToken);

        #endregion

        /// <summary>
        /// 发送 JSON 请求。
        /// </summary>
        private Task<ApiResponse<TResponse>> SendJsonAsync<TResponse>(string path, object body, CancellationToken cancellationToken = default)
            => SendAsync<TResponse>(path, HttpMethod.Post, body, null, cancellationToken);

        /// <summary>
        /// 发送 PUT JSON 请求。
        /// </summary>
        private Task<ApiResponse<TResponse>> PutJsonAsync<TResponse>(string path, object body, CancellationToken cancellationToken = default)
            => SendAsync<TResponse>(path, HttpMethod.Put, body, null, cancellationToken);

        /// <summary>
        /// 发送带 JSON 请求体的 DELETE 请求。
        /// </summary>
        private Task<ApiResponse<TResponse>> DeleteJsonAsync<TResponse>(string path, object body, CancellationToken cancellationToken = default)
            => SendAsync<TResponse>(path, HttpMethod.Delete, body, null, cancellationToken);

        /// <summary>
        /// 发送带查询参数的 DELETE 请求。
        /// </summary>
        private Task<ApiResponse<TResponse>> DeleteAsync<TResponse>(string path, object query, CancellationToken cancellationToken)
            => SendAsync<TResponse>(path, HttpMethod.Delete, null, query, cancellationToken);

        /// <summary>
        /// 发送请求并反序列化响应
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="body"></param>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="WebpowerXApiException"></exception>
        /// <exception cref="WebpowerXApiRequestException"></exception>
        private async Task<ApiResponse<TResponse>> SendAsync<TResponse>(string path, HttpMethod method, object? body, object? query, CancellationToken cancellationToken)
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
                // 接入层校验失败（如 IP 白名单、签名问题）时，服务端仍会返回 JSON 信封，尽量还原成结构化异常。
                var errorEnvelope = TryDeserialize<ApiResponse<EmptyResult>>(content);
                if (errorEnvelope != null && errorEnvelope.Code != 0)
                {
                    throw new WebpowerXApiException(errorEnvelope.Code, errorEnvelope.Message, errorEnvelope.ResponseId, errorEnvelope.TraceNumber);
                }

                throw new WebpowerXApiRequestException($"HTTP {(int)response.StatusCode} from WebpowerX API: {content}", null, (int)response.StatusCode);
            }

            var envelope = JsonSerializer.Deserialize<ApiResponse<TResponse>>(content, JsonDefaults.Options)
                ?? throw new WebpowerXApiRequestException("Failed to deserialize WebpowerX API response.");

            if (!envelope.IsSuccess)
            {
                throw new WebpowerXApiException(envelope.Code, envelope.Message, envelope.ResponseId, envelope.TraceNumber);
            }

            return envelope;
        }

        /// <summary>
        /// 尝试反序列化响应体，失败时返回 null 而不是抛出异常。
        /// </summary>
        private static T? TryDeserialize<T>(string content) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(content, JsonDefaults.Options);
            }
            catch (JsonException)
            {
                return default;
            }
        }

        /// <summary>
        /// 发送 GET 请求并反序列化响应。
        /// </summary>
        private Task<ApiResponse<TResponse>> GetAsync<TResponse>(string path, object? query, CancellationToken cancellationToken)
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
            else
            {
                var parameters = GetQueryParameters(query.GetType());
                for (var i = 0; i < parameters.Length; i++)
                {
                    AppendPair(pairs, parameters[i].Name, parameters[i].Property.GetValue(query, null));
                }
            }

            return pairs.Count == 0 ? string.Empty : "?" + string.Join("&", pairs);
        }

        /// <summary>
        /// 读取查询对象的参数定义，结果按类型缓存，避免每次请求重复反射。
        /// </summary>
        private static QueryParameter[] GetQueryParameters(Type type)
            => QueryParameterCache.GetOrAdd(type, t => t
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead)
                .Select(p => new QueryParameter(GetQueryParameterName(p), p))
                .ToArray());

        /// <summary>
        /// 获取查询参数名，优先使用 <see cref="JsonPropertyNameAttribute" />。
        /// </summary>
        private static string GetQueryParameterName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attribute != null ? attribute.Name : property.Name;
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

            if (value is IEnumerable values && !(value is string))
            {
                foreach (var item in values)
                {
                    AppendPair(pairs, key, item);
                }

                return;
            }

            var text = value is bool flag
                ? (flag ? "true" : "false")
                : Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            pairs.Add(Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString(text));
        }


        /// <summary>
        /// 单个查询参数的定义。
        /// </summary>
        private sealed class QueryParameter
        {
            public QueryParameter(string name, PropertyInfo property)
            {
                Name = name;
                Property = property;
            }

            public string Name { get; }

            public PropertyInfo Property { get; }
        }
    }
}

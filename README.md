# WebpowerX.Client

一个面向开发者使用的 WebpowerX iEmail 客户端 SDK。

## 特性

- `netstandard2.1`
- 统一签名生成
- 统一响应封装
- 统一异常类型
- 支持扩展字段

## 快速开始

```csharp
using Microsoft.Extensions.DependencyInjection;
using WebpowerX.Client.Models;

var services = new ServiceCollection();
services.AddWebpowerXApiClient(options =>
{
    options.BaseUrl = WebpowerXApiEnvironments.AsiaProduction;
    options.AccessKey = "your-access-key";
    options.AccessKeySecret = "your-access-key-secret";
});

var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IWebpowerXApiClient>();

var response = await client.SendTransEmailAsync(new SingleEmailRequest
{
    SenderAddressSn = "senderAddressSn",
    Subject = "账户安全验证码",
    Content = new EmailContent { Type = "html", Value = "<p>Hello</p>" },
    Recipient = new Recipient { Email = "user@example.com", Name = "张三" },
    SubstitutionObj = new Substitution
    {
        Data = new Dictionary<string, object?> { ["code"] = "839201" }
    }
});

// 批量发送普通邮件：收件人数组与单封发送不同，最多 1000 人，不支持 Enjoy 业务数据。
var bulkResponse = await client.SendBulkEmailsAsync(new BulkEmailRequest
{
    SenderAddressSn = "senderAddressSn",
    Subject = "订单 {$orderNo} 已发货",
    Content = new EmailContent { Type = "html", Value = "<p>您好，{$name}，订单 {$orderNo} 已发货。</p>" },
    Recipients = new List<Recipient>
    {
        new Recipient { Email = "alice@example.com", Name = "Alice" },
        new Recipient { Email = "bob@example.com", Name = "Bob" }
    }
});

var domain = await client.GetDomainAsync(new DomainQuery
{
    Domain = "example.com"
});
```

## 已实现接口

- 发送单封事务邮件
- 发送单封普通邮件
- 批量发送普通邮件
- 创建个性化发送任务
- 创建固定模板发送任务
- 个性化任务发送
- 固定模板任务发送
- 固定模板任务批量发送
- 云文件任务创建
- 云文件素材任务创建
- 发件地址配置
- 回复地址配置
- 联系人管理
- 联系人属性管理
- 标签管理
- 内容素材管理
- 发送数据统计

## 打包与发布

```powershell
# 只生成本地 NuGet 包
powershell -ExecutionPolicy Bypass -File .\nupkg\pack.ps1 -Version 1.0.0

# 发布到 NuGet.org，API Key 可通过参数传入
powershell -ExecutionPolicy Bypass -File .\nupkg\publish.ps1 -Version 1.0.0 -ApiKey "your-nuget-api-key" -SkipDuplicate

# 或者先设置环境变量，避免 API Key 出现在命令历史里
$env:NUGET_API_KEY = "your-nuget-api-key"
powershell -ExecutionPolicy Bypass -File .\nupkg\publish.ps1 -Version 1.0.0 -SkipDuplicate
```

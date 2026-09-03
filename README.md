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

var response = await client.SendSingleTransactionalEmailAsync(new WebpowerXSingleEmailRequest
{
    SenderAddressSn = "senderAddressSn",
    Subject = "账户安全验证码",
    Content = new WebpowerXContent { Type = "html", Value = "<p>Hello</p>" },
    Recipient = new WebpowerXRecipient { Email = "user@example.com", Name = "张三" }
});

var domain = await client.GetDomainAsync("example.com");
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

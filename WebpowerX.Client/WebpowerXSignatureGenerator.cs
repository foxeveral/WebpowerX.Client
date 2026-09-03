using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace WebpowerX.Client
{
    /// <summary>
    /// 按文档规则生成 access-sign。
    /// </summary>
    public static class WebpowerXSignatureGenerator
    {
        /// <summary>
        /// 使用当前时间戳或指定时间戳，计算请求签名。
        /// </summary>
        /// <param name="accessKeySecret">接口密钥。</param>
        /// <param name="timestampMilliseconds">可选的毫秒时间戳，便于测试和排查。</param>
        /// <returns>经过加密并进行 URL 编码后的签名字符串。</returns>
        public static string Generate(string accessKeySecret, long? timestampMilliseconds = null)
        {
            if (string.IsNullOrWhiteSpace(accessKeySecret))
            {
                throw new ArgumentException("Access key secret is required.", nameof(accessKeySecret));
            }

            var timestamp = timestampMilliseconds ?? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var payload = timestamp.ToString(CultureInfo.InvariantCulture);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = NormalizeKey(accessKeySecret);

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(payload);
            var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Uri.EscapeDataString(Convert.ToBase64String(cipherBytes));
        }

        /// <summary>
        /// WebpowerX 文档要求使用 AES-128-ECB。这里把密钥整理成 16 字节，满足算法要求。
        /// </summary>
        private static byte[] NormalizeKey(string accessKeySecret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(accessKeySecret);
            if (keyBytes.Length == 16)
            {
                return keyBytes;
            }

            var normalized = new byte[16];
            Array.Copy(keyBytes, normalized, Math.Min(keyBytes.Length, normalized.Length));
            return normalized;
        }
    }
}

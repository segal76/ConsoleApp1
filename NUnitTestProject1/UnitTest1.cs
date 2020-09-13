using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task Test1Async()
        {
            const string iamToken = "CggVAgAAABoBMxKABKeJ4ZiLGK8qP8gHmAwdFUnZzIodF_e2QImoFSW26tfJHuEY5M4hnk84js3qJeSLqaCWzKnaGns8Vkdc2y2g0-7svm7Q3sp2_66xTL_JwJd3eRrFFaVQCcBwoLbtR3AIvQ8QwyV5DXFa0MN2GzanFY1vToCjhgN4eE0zTCoDkY76dXtHjl-YsAcdM12lGNw9e40WZsvMtNWvmvWOSvlXu8r9UjpdqNCRpxVaQ2-1qhcUV0fvwIZBjx_gmaOExpmHjrv_2hLfMTqopjOTCfwU2vWzgmUe-0700h2gI2i3RokcQBYFPZGTjUopuHhim-zBO8A-DLZAKaFLlOBY3JfBh5d6fPGRQbZsGw6PTRGx67VYuTgmiu2RdN1PgqvuLUU_aAabG1iK4n_5IUw13d_S3O0PnBJ__xQ-k1exCF0lF1SRHgrZ1aHnh2d8jVbw5jN9wmtt21hSKc2QGMXeYziNt6_XdPq3T54m6yqdbEIY5s9UVkDmtK3_AF9zGnheg-LZFsoafwy5i-tsHGFIy2NWLose8BDXT4G7LPAne1VbsRf5TK3F6JoNsek4J92W-r2BVD2B0pbia0zgva1JY_-fOcAI0PUGHnNVqpPF0EC-vfwe4IHpiyYS5SS0LSXaf87Y9Nm1_LpWjxZ9L5xfy6jri_2Ku_sZaVgS_rSJsRz5-N-SGiQQx-H3-gUYh7P6-gUiFgoUYWpldGpvaDhpa3Q0bmdobGFtOXM="; // Укажите IAM-токен.
            const string folderId = "b1gq8kc4alrnhtiufnfe"; // Укажите ID каталога.

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + iamToken);
            var values = new Dictionary<string, string>
      {
        { "text", "привет петрович" },
        { "lang", "ru-RU" },
        { "folderId", folderId }
      };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://tts.api.cloud.yandex.net/speech/v1/tts:synthesize", content);
            var responseBytes = await response.Content.ReadAsByteArrayAsync();
            File.WriteAllBytes("c:\\1\\speech.ogg", responseBytes);

            var fileExits = File.Exists("c:\\1\\speech.ogg");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            Assert.AreEqual(fileExits, true);
        }
    }
}
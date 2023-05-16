using API.SDK;
using System.Text.RegularExpressions;

namespace API.Helper
{
    public class GorillaHelper
    {
        public static string ToDo(string? something)
        {
            string msg = "";
            try
            {
                if (something is null) return msg;

                if (something.StartsWith("呼叫大猩猩"))
                {
                    var q = Regex.Split(something, "呼叫大猩猩");

                    if (string.IsNullOrEmpty(q[1]))
                        msg = "聽說香蕉漲價了!";
                    else
                        msg = $"{ChatGPT.CallChatGPT(q[1]).choices.FirstOrDefault().text}";
                }
                else if (something.StartsWith("猩猩數香蕉"))
                {
                    var q = Regex.Split(something, "猩猩數香蕉");

                    if (string.IsNullOrEmpty(q[1]))
                        msg = "你不給我香蕉要怎麼數?";
                    else
                        msg = GComputer(q[1]);
                }
            }
            catch (Exception ex)
            {
                msg = $"猩猩腦袋壞掉了 {ex}";
            }
            return msg;
        }

        /// <summary>
        /// 計算機
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static string GComputer(string num)
        {
            List<string> numList = num.Split('+').ToList();

            string req;
            try
            {
                int count = 0;

                numList.ForEach(v =>
                {
                    count += Convert.ToInt32(v);
                });

                if (count < 0)
                    req = $"我就問，有 {count} 根香蕉，這種東西嗎?";
                else
                    req = $"一共 {count} 根香蕉";
            }
            catch (Exception)
            {
                req = "你這個老師沒有教，我不會，不要問我!";
            }

            return req;
        }
    }
}

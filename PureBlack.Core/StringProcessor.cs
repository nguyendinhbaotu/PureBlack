using System.Text.RegularExpressions;

namespace PureBlack.Core
{
    public class StringProcessor
    {
        public string TrimStringByWord(string s, int maxLength)
        {
            if (s == null)
            {
                return null;
            }

            var ret = s;
            if (ret.Trim().Length > maxLength)
            {
                ret = ret.Trim().Substring(0, maxLength);
                if (!ret.EndsWith(" ") && s[maxLength] != ' ' && (ret = ret.Trim()).Contains(" "))
                {
                    ret = ret.Substring(0, ret.LastIndexOf(' ')).Trim();
                }
                ret = string.Format("{0}...", ret.Trim());
            }
            return ret;

        }

        public string RemoveHtmlTags(string html)
        {
            // Faster than using regular expression
            if (html == null) { return null; }
            html = html.Replace("&nbsp;", " ")
                       .Replace("<br>", "\n")
                       .Replace("<br />", "\n")
                       .Replace("<p", "\n<p")
                       .Replace("<div", "\n<div");
            char[] array = new char[html.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < html.Length; i++)
            {
                char let = html[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public string ToAscii(string source)
        {
            string unicode = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴđĐ",
                     ascii = "aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYdD";

            for (var i = 0; i < unicode.Length; i++)
            {
                source = source.Replace(unicode[i], ascii[i]);
            }
            return source;
        }

        public string ToUrlFriendly(string source)
        {
            source = ToAscii(source).Trim().ToLower();
            source = source.Replace(' ', '-');
            source = source.Replace("&nbsp;", "-");
            source = new Regex("[^0-9a-z-]").Replace(source, string.Empty);
            while (source.IndexOf("--") > -1)
            {
                source = source.Replace("--", "-");
            }
            return source;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oven_Application.common
{
    class oLogin
    {
        // URL 주소
        //private static string _loginURL = "http://localhost:5000/api/v1/app/login"; // 추후 변경해야할 부분
        private static string _loginURL = "http://34.64.107.34:5000/api/v1/app/login"; 
        public static string LoginURL { get => _loginURL; }

        // Access Token & Refresh Token
        private static string _accessToken = string.Empty;
        public static string AccessToken { get => _accessToken; set => _accessToken = value; }

        private static string _refreshToken = string.Empty;
        public static string RefreshToken { get => _refreshToken; set => _refreshToken = value; }
    }
}

using UnityEngine.Networking;

namespace Mirage.Cloud
{
    public static class Extensions
    {
        public static bool IsOk(this UnityWebRequest webRequest)
        {
            return 200 <= webRequest.responseCode && webRequest.responseCode <= 299;
        }
    }
}

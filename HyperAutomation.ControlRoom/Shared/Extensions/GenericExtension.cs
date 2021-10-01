using HyperAutomation.ControlRoom.Shared.Models;
using HyperAutomation.ControlRoom.Shared.Models;
using System.Net.Http;

namespace HyperAutomation.ControlRoom.Shared.Extensions
{
    public static class GenericExtension
    {
        public static BaseResult<T> ToResult<T>(
            this T data)
        {
            var result = new BaseResult<T>();

            if (data == null)
            {
                result.Message = "data está nulo";
            }

            result.Data = data;
            result.Success = true;

            return result;
        }

        public static void SetUsersToNull<T>(this T obj) where T : EntityInfomation
        {
            obj.CreatedBy = null;
            obj.ModifiedBy = null;
            obj.DeletedBy = null;
        }

        public static void SetUsersToNull(this UserProfile obj)
        {
            obj.ModifiedBy = null;
        }

        public static string GetResponseErrorMessage<T>(this T response) where T: HttpResponseMessage
        {
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
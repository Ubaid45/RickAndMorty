using System.Collections.Specialized;
using Microsoft.AspNetCore.Http;

namespace RickAndMorty.Application.Common;

public static class StringUtils
{
    public static string BuildQueryString(IQueryCollection queryParams)
    {
        NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

        foreach (var parameter in queryParams)
        {
            queryString.Add(parameter.Key, parameter.Value);
        }

        return queryString.ToString(); 
    }
}
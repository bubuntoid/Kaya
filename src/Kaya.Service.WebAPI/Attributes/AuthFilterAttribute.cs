using Kaya.Service.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Kaya.Service.WebAPI.Attributes;

public class AuthFilterAttribute : TypeFilterAttribute
{
    public AuthFilterAttribute() : base(typeof(AuthFilter))
    {
        
    }
}
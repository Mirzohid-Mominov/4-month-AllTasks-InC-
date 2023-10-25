using System.Globalization;

namespace MiddleWares
{
    public class CultureMiddleWare
    {
        private readonly RequestDelegate _next;

        public CultureMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];

            if(!string .IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentCulture = culture;
            }

            await _next(context);
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Digify.Registration.Api.Models;
using Digify.Registration.Application;
using Digify.Registration.Application.Models;
using Digify.Registration.Application.SelectParameters;
using Digify.Registration.Application.Services;
using Digify.Registration.Core.Entities;
using System.Text;

namespace Digify.Registration.Api.Routes
{
    public static class CompanyRoute
    {
        public static void Map(WebApplication app)
        {
            var v1Group = app.MapGroup("/v1/companies").WithTags("Companies");

            v1Group.MapGet("/", SearchCompanies).WithName("SearchCompanies").WithOpenApi();

            v1Group.MapGet("/{id:Guid}", FindCompany).WithName("FindCompany").WithOpenApi();

            v1Group.MapPost("/", CreateCompany).WithName("CreateCompany").WithOpenApi();

            v1Group.MapPut("/{id:Guid}", UpdateCompany).WithName("UpdateCompany").WithOpenApi();

            v1Group.MapDelete("/{id:Guid}", DeleteCompany).WithName("DeleteCompany").WithOpenApi();
        }

        private static async Task<Results<Ok<ApiResponse<SelectResult<CompanyResponse>>>, NotFound>> SearchCompanies(      
        [FromServices] IUseCase<CompanySelectParameter,SelectResult<CompanyApplicationModel>> useCase,
        [FromQuery] string? code,
        [FromQuery] string? name,
        [FromQuery] string? npwp,
        [FromQuery] string? sortBy = "code",
        [FromQuery] string? sortDirection = "asc",
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
        {
            CompanySelectParameter selectParameter = new CompanySelectParameter() { Code = code, Name = name, NPWP = npwp, SortBy = sortBy, SortDirection = sortDirection == "asc" ? SortDirection.Ascending : SortDirection.Descending, Page = page, PageSize = pageSize };
            var result = await useCase.Execute(selectParameter);

            if (result == null)
            {
                return TypedResults.NotFound();
            }
            else
            {
                var selectResult = new SelectResult<CompanyResponse>();
                selectResult.TotalItems = result.TotalItems;
                selectResult.TotalPages = result.TotalPages;
                selectResult.CurrentPage = result.CurrentPage;
                selectResult.PageSize = result.PageSize;
                if (result.Data != null)
                {
                    selectResult.Data = result.Data.Select(t => new CompanyResponse() { Id = t.Id, Code = t.Code, CompanyName = t.CompanyName, NPWP = t.NPWP, DirectorName = t.DirectorName, PICName = t.PICName, Email = t.Email, PhoneNumber = t.PhoneNumber, DocumentNPWPName = t.DocumentNPWPName, DocumentPowerOfAttorneyName = t.DocumentPowerOfAttorneyName }).ToList();
                }

                ApiResponse<SelectResult<CompanyResponse>> apiResponse = new ApiResponse<SelectResult<CompanyResponse>>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>(), Data = selectResult };

                return TypedResults.Ok<ApiResponse<SelectResult<CompanyResponse>>>(apiResponse);
            }            
        }

        private static async Task<Results<Ok<ApiResponse<CompanyResponse>>, NotFound>> FindCompany(Guid id, [FromServices] IUseCase<Guid,CompanyApplicationModel> useCase)
        {
            CompanyApplicationModel? result = await useCase.Execute(id);

            if (result == null)
            {
                return TypedResults.NotFound();
            }
            else
            {
                var findResult = new CompanyResponse() { Id = result.Id, Code = result.Code, CompanyName = result.CompanyName, NPWP = result.NPWP, DirectorName = result.DirectorName, PICName = result.PICName, Email = result.Email, PhoneNumber = result.PhoneNumber, DocumentNPWPName = result.DocumentNPWPName, DocumentPowerOfAttorneyName = result.DocumentPowerOfAttorneyName };

                ApiResponse<CompanyResponse> apiResponse = new ApiResponse<CompanyResponse>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>(), Data = findResult };

                return TypedResults.Ok<ApiResponse<CompanyResponse>>(apiResponse);
            }
        }

        private static async Task<Results<Created<ApiResponse<CompanyResponse>>, BadRequest<ApiResponse<CompanyResponse>>>> CreateCompany(CompanyRequest request, [FromKeyedServices(AppConst.SERVICE_KEY_CREATE)] IUseCase<CompanyApplicationModel, bool> useCase)
        {
            Guid newId = Guid.NewGuid();
            Guid userId = Guid.Empty; 
            CompanyApplicationModel company = new CompanyApplicationModel() { Id = newId, Code = "", CompanyName = request.CompanyName, NPWP = request.NPWP, DirectorName = request.DirectorName, PICName = request.PICName, Email = request.Email, PhoneNumber = request.PhoneNumber, DocumentNPWP = request.DocumentNPWP, DocumentPowerOfAttorney = request.DocumentPowerOfAttorney, DocumentNPWPName = request.DocumentNPWPName, DocumentPowerOfAttorneyName = request.DocumentPowerOfAttorneyName , Deleted = false, CreatedDate = DateTime.Now, CreatedUserId = userId };

            try
            {
                bool result = await useCase.Execute(company);

                CompanyResponse CompanyResponse = new CompanyResponse() { Id = company.Id, Code = company.Code, CompanyName = company.CompanyName, NPWP = company.NPWP, DirectorName = company.DirectorName, PICName = company.PICName, Email = company.Email, PhoneNumber = company.PhoneNumber, DocumentNPWPName = company.DocumentNPWPName, DocumentPowerOfAttorneyName = company.DocumentPowerOfAttorneyName };
                ApiResponse<CompanyResponse> apiResponse = new ApiResponse<CompanyResponse>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>(), Data = CompanyResponse };

                return TypedResults.Created($"/Companies/{company.Id}", apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponse<CompanyResponse> apiResponse = new ApiResponse<CompanyResponse>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>() {Messages.Translate(ex) }, Data = null };

                return TypedResults.BadRequest<ApiResponse<CompanyResponse>>(apiResponse);
            }
        }

        private static async Task<Results<Ok<ApiResponse<CompanyResponse>>, BadRequest<ApiResponse<CompanyResponse>>>> UpdateCompany(Guid id, CompanyRequest request, [FromKeyedServices(AppConst.SERVICE_KEY_UPDATE)] IUseCase<CompanyApplicationModel, bool> useCase)
        {
            Guid userId = Guid.Empty;

            CompanyApplicationModel company = new CompanyApplicationModel() { Id = id, Code = "", CompanyName = request.CompanyName, NPWP = request.NPWP, DirectorName = request.DirectorName, PICName = request.PICName, Email = request.Email, PhoneNumber = request.PhoneNumber, DocumentNPWP = Encoding.ASCII.GetBytes("TEMP"), DocumentPowerOfAttorney = Encoding.ASCII.GetBytes("TEMP"), DocumentNPWPName = request.DocumentNPWPName, DocumentPowerOfAttorneyName = request.DocumentPowerOfAttorneyName, Deleted = false, UpdatedDate = DateTime.Now, UpdatedUserId = userId };

            try
            {
                bool result = await useCase.Execute(company);

                CompanyResponse CompanyResponse = new CompanyResponse() { Id = company.Id, Code = company.Code, CompanyName = company.CompanyName, NPWP = company.NPWP, DirectorName = company.DirectorName, PICName = company.PICName, Email = company.Email, PhoneNumber = company.PhoneNumber, DocumentNPWPName = company.DocumentNPWPName, DocumentPowerOfAttorneyName = company.DocumentPowerOfAttorneyName };
                ApiResponse<CompanyResponse> apiResponse = new ApiResponse<CompanyResponse>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>(), Data = CompanyResponse };

                return TypedResults.Ok<ApiResponse<CompanyResponse>>(apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponse<CompanyResponse> apiResponse = new ApiResponse<CompanyResponse>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string>() { Messages.Translate(ex) }, Data = null };

                return TypedResults.BadRequest<ApiResponse<CompanyResponse>>(apiResponse);
            }
        }

        private static async Task<Results<Ok<ApiResponse<bool>>, BadRequest<ApiResponse<bool>>>> DeleteCompany([FromHeader(Name = "Tenant-Code")] Guid tenantId, [FromHeader(Name = "User-Code")] Guid userId, Guid id, [FromServices] IUseCase<DeleteParameter,bool> useCase)
        {
            try
            {
                DeleteParameter deleteParameter = new DeleteParameter() { Id = id , UserId = userId };
                bool result = await useCase.Execute(deleteParameter);

                ApiResponse<bool> apiResponse = new ApiResponse<bool>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string> { Messages.DATA_DELETED }, Data = result };

                return TypedResults.Ok<ApiResponse<bool>>(apiResponse);
            }
            catch (Exception ex)
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>() { IsSuccess = true, StatusCode = 200, StatusMessages = new List<string> { Messages.Translate(ex) } };

                return TypedResults.BadRequest(apiResponse);
            }
        }
    }
}

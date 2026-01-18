using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data.UnitOfWork;

namespace RealEstateAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public TestController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("check-database")]
    public async Task<IActionResult> CheckDatabase()
    {
        try
        {
            // PropertyType sayısını kontrol et
            var propertyTypeCount = await _unitOfWork.PropertyTypes.CountAsync();
            
            // Property sayısını kontrol et
            var propertyCount = await _unitOfWork.Properties.CountAsync();
            
            // Inquiry sayısını kontrol et
            var inquiryCount = await _unitOfWork.Inquiries.CountAsync();

            return Ok(new
            {
                message = "Database bağlantısı başarılı!",
                propertyTypes = propertyTypeCount,
                properties = propertyCount,
                inquiries = inquiryCount,
                timestamp = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "Hata oluştu!",
                error = ex.Message
            });
        }
    }

    [HttpGet("repository-test")]
    public IActionResult RepositoryTest()
    {
        return Ok(new
        {
            message = "Repository'ler başarıyla inject edildi!",
            properties = _unitOfWork.Properties != null,
            propertyTypes = _unitOfWork.PropertyTypes != null,
            propertyImages = _unitOfWork.PropertyImages != null,
            inquiries = _unitOfWork.Inquiries != null,
            timestamp = DateTime.UtcNow
        });
    }
}
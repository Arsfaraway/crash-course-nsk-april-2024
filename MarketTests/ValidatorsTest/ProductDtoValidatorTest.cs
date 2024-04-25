using FluentValidation;
using FluentValidation.Results;
using Market.Controllers;
using Market.DAL.Repositories.Products;
using Market.DTO;
using Market.Enums;
using Market.Models;
using Market.Validators;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace MarketTests.ValidatorsTest;

[TestFixture]
public class ProductDtoValidatorTest
{
    private IValidator<ProductDto> _validator;
    // private IValidator<ProductDto> fakevalidator;
    private static ProductDto CreateDefaultProductDto()
    {
        return new ProductDto
        {
            Category = ProductCategory.Food,
            Description = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            PriceInRubles = 1,
            SellerId = Guid.NewGuid(),
            Id = Guid.NewGuid()
        };
    }
    
    [OneTimeSetUp]
    public void OneTimpeSetup()
    {
        _validator = new ProductDtoValidator();
        // validator = Substitute.For<IValidator<ProductDto>>();
        // моки
        // validator.Validate(null!).ReturnsForAnyArgs(new ValidationResult());
    }
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void EmptyProductDtoShouldFail()
    {
        var productDto = new ProductDto();
        
        var validationResult = _validator.Validate(productDto);

        Assert.IsFalse(validationResult.IsValid);
    }

    [Test]
    public void NotEmptyProductDtoIdShouldFail()
    {
        var productDto = CreateDefaultProductDto();
        productDto.Id = Guid.Empty;
            
        var validationResult = _validator.Validate(productDto);
        
        Assert.False(validationResult.IsValid);
    }
    
    [Test]
    public void NotEmptyProductDtoIdShouldPass()
    {
        var productDto = CreateDefaultProductDto();
        productDto.Id = Guid.NewGuid();
            
        var validationResult = _validator.Validate(productDto);
        
        Assert.True(validationResult.IsValid);
    }
    
    [Test]
    public void NameLengthProductDtoShouldFail()
    {
        var productDto = CreateDefaultProductDto();
        productDto.Name = "a";
        
        var validationResult = _validator.Validate(productDto);
        
        Assert.False(validationResult.IsValid);
    }
    
    [Test]
    public void NameLengthProductDtoShouldPass()
    {
        var productDto = CreateDefaultProductDto();
        productDto.Name = "aaaaa";
        
        var validationResult = _validator.Validate(productDto);
        
        Assert.True(validationResult.IsValid);
    }
    
    [Test]
    public void PriceInRublesGreaterThanZeroProductDtoShouldFail()
    {
        var productDto = CreateDefaultProductDto();
        productDto.PriceInRubles = 0;
        
        var validationResult = _validator.Validate(productDto);
        
        Assert.False(validationResult.IsValid);
    }
    
    [Test]
    public void PriceInRublesGreaterThanZeroProductDtoShouldPass()
    {
        var productDto = CreateDefaultProductDto();
        productDto.PriceInRubles = 100;
        
        var validationResult = _validator.Validate(productDto);
        
        Assert.True(validationResult.IsValid);
    }
    
    

    // [Test]
    // public async Task Test2()
    // {
    //     var productsRepository = Substitute.For<ProductsRepository>();
    //
    //     productsRepository.GetProductsAsync().ReturnsForAnyArgs(new List<Product>());
    //     
    //     var mainValidator = Substitute.For<MainValidator>();
    //     var productsController = new ProductsController(productsRepository, mainValidator);
    //
    //     await productsController.SearchProductsAsync(new SearchProductRequestDto(null, null, null));
    //
    //     await productsRepository.GetProductsAsync().ReceivedWithAnyArgs(1);
    // }
    
}
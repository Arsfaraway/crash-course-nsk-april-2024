using FluentValidation;
using Market.DTO;
using Market.Enums;

namespace MarketTests.ValidatorsTest;

[TestFixture]
public class SearchProductRequestDtoValidator
{
    private IValidator<SearchProductRequestDto> _validator;

    private static SearchProductRequestDto createDefaultSearchProductRequestDto(string productName = "chocolate",
        SortType sortType = new SortType(), ProductCategory category = new ProductCategory(),
        bool ascending = true, int skip = 0, int take = 50)
    {
        return new SearchProductRequestDto(
            productName,
            sortType,
            category,
            ascending,
            skip,
            take);
    }

    [OneTimeSetUp]
    public void OneTimpeSetup()
    {
        _validator = new Market.Validators.SearchProductRequestDtoValidator();
    }

    // todo использование Arrange, Act и Assert в данных микро тестах считаю излишним
    [Test]
    public void FilledSearchProductRequestDtoShouldPass()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto();

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.IsTrue(validationResult.IsValid);
    }

    [Test]
    public void NameLengthSearchProductRequestDtoShouldFail()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto("");

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.False(validationResult.IsValid);
    }

    [Test]
    public void NameLengthSearchProductRequestDtoShouldPass()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto(productName: "Banana");

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.True(validationResult.IsValid);
    }

    [Test]
    public void SkipGreaterThanOrEqualToSearchProductRequestDtoShouldFail()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto(skip: -1);

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.False(validationResult.IsValid);
    }

    [Test]
    public void SkipGreaterThanOrEqualToSearchProductRequestDtoShouldPass()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto(skip: 5);

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.True(validationResult.IsValid);
    }

    [Test]
    public void TakeInclusiveBetweenSearchProductRequestDtoShouldFail()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto(take: 102);

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.False(validationResult.IsValid);
    }

    [Test]
    public void TakeInclusiveBetweenSearchProductRequestDtoShouldPass()
    {
        var searchProductRequestDto = createDefaultSearchProductRequestDto(take: 10);

        var validationResult = _validator.Validate(searchProductRequestDto);

        Assert.True(validationResult.IsValid);
    }
}
namespace WebApi.Services;

public class CategoryService(CategoryHandler.CategoryHandlerClient categoryHandler)
{
    private readonly CategoryHandler.CategoryHandlerClient _categoryHandler = categoryHandler;
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        var response = await _categoryHandler.GetCategoriesAsync(new GetCategoriesRequest());
        if (response == null)
            return [];

        return response.Categories.Select(c => new CategoryModel
        {
            Id = c.Id,
            Description = c.Description
        });
    }

    public async Task<CategoryModel> GetCategoryByIdAsync(int id)
    {
        var response = await _categoryHandler.GetCategoryByIdAsync(new GetCategoryByIdRequest { Id = id });
        if (response == null)
            return null!;

        return new CategoryModel
        {
            Id = response.Category.Id,
            Description = response.Category.Description
        };
    }
}
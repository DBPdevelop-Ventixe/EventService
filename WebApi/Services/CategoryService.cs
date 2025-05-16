namespace WebApi.Services;

public class CategoryService(CategoryHandler.CategoryHandlerClient categoryHandler)
{
    private readonly CategoryHandler.CategoryHandlerClient _categoryHandler = categoryHandler;
    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
    {
        try
        {
            var response = await _categoryHandler.GetCategoriesAsync(new GetCategoriesRequest());
            if (response == null)
                return [];

            return response.Categories.Select(c => new CategoryModel
            {
                Id = c.Id,
                Description = c.Description
            });
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public async Task<CategoryModel> GetCategoryByIdAsync(int id)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }
}
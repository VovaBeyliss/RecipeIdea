namespace RecipeIdea.Extensions;

public static class ListExtensions {
    public static async Task<List<T>> ReverseAsync<T>(this Task<List<T>> sourceTask) {
        List<T> list = await sourceTask;
        List<T> result = new List<T>();

        for (int i = list.Count - 1; i >= 0; i--) {
            result.Add(list[i]);
        }

        return result;
    }
}
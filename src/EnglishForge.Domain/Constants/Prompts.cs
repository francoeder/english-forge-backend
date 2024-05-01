namespace EnglishForge.Domain.Constants
{
    public static class Prompts
    {
        public const string CompleteQuestionListVerbConjugationPrompt = "Act as a English Teacher. Here are my requirements: I need questions about {0}, the first version with empty spaces to fill in, and the second version with the full question highlighting the correct option. You should give me: - A list with {1} questions following the definition above; - For each question, a list of 4 options where only one is correct; - The result should be a valid array JSON; Example:";
    }
}

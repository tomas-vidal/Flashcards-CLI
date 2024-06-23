namespace Flashcards_CLI 
{
    internal class FlashcardModel 
    {
        public int Id { get; set;}
        public string Front { get; set;} = string.Empty;
        public string Back { get; set;} = string.Empty;
        public int Stack_Id { get; set;}
    }
}
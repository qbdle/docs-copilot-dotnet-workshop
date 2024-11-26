namespace API.Entities {
  public record TodoTask {
    public uint Id { get; init; }
    public string Title { get; init; }
    public string Notes { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime DeadlineDate { get; init; }

    public TodoTask(uint id, string title, string notes, DateTime deadlineDate) {
      Id = id;
      Title = title;
      Notes = notes;
      CreationDate = DateTime.Now;
      DeadlineDate = deadlineDate;
    }
  }
}
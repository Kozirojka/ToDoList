﻿namespace ToDoTask.Domain;

//Our entity
public class DoTask
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get;  set; }
}
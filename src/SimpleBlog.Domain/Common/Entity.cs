﻿namespace SimpleBlog.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

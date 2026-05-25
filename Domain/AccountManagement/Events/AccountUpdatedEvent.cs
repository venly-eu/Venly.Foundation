using Domain.AccountManagement.ValueObjects;
using Domain.Common;

namespace Domain.AccountManagement.Events;

public record AccountUpdatedEvent(AccountId AccountId) : DomainEvent;
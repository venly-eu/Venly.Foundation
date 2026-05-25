using Domain.AccountManagement.ValueObjects;
using Domain.Common;

namespace Domain.AccountManagement.Events;

public record AccountDeactivatedEvent(AccountId AccountId) : DomainEvent;
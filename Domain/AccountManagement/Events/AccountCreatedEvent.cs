using Domain.AccountManagement.ValueObjects;
using Domain.Common;

namespace Domain.AccountManagement.Events;

public record AccountCreatedEvent(AccountId AccountId, string Username, string Email) : DomainEvent;
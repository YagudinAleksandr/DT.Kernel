# DT.Kernel - Shared Kernel для DDD

[![NuGet Version](https://img.shields.io/nuget/v/DT.Kernel.svg?logo=nuget)](https://www.nuget.org/packages/DT.Kernel)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DT.Kernel.svg)](https://www.nuget.org/packages/DT.Kernel)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE.md)

# Описание
Этот проект представляет собой общее ядро (Shared Kernel) для реализации Domain-Driven Design (DDD) в приложениях. Он содержит базовые абстракции и реализации для сущностей, агрегатов, value objects, доменных событий и исключений.

## Основные компоненты

### Базовые абстракции

- **Entity<TKey>** - базовая сущность с идентификатором
- **AggregateRoot<TKey>** - корень агрегата с поддержкой доменных событий
- **ValueObject** - базовый value object с реализацией сравнения
- **IAggregateRoot** - интерфейс корня агрегата

### Доменные события

- **IDomainEvent** - интерфейс доменного события
- Поддержка коллекции событий в агрегатах

### Исключения доменного уровня

- **DomainException** - базовое доменное исключение
- **DomainRequiredFieldException** - обязательное поле не заполнено
- **DomainMinLengthFieldException** - минимальная длина не соблюдена
- **DomainMaxLengthFieldException** - максимальная длина превышена
- **DomainRangeFieldException** - значение вне допустимого диапазона
- **DomainValidationFieldException** - невалидное поле
- **DomainResourceNotFoundException** - ресурс не найден
- **DomainResourceAlreadyExistsException** - ресурс уже существует

### Коды для локализации

- **DomainExceptionCodes** - коды доменных исключений
- **DomainFieldCodes** - коды доменных полей

### Репозитории (интерфейсы)

- **IAddItem<TAggregate>** - добавление сущностей
- **IGetItem<TAggregate, TKey>** - получение сущностей
- **IUpdateItem<TAggregate>** - обновление сущностей
- **IDeleteItem<TAggregate>** - удаление сущностей
- **IUnitOfWork** - Unit of Work паттерн

## Использование

### Создание сущности

```csharp
public class User : Entity<Guid>
{
    public string Name { get; private set; }
    public Email Email { get; private set; }

    public User(Guid id, string name, Email email) : base(id)
    {
        Name = name;
        Email = email;
    }
}
```

### Создание агрегата
```csharp
public class Order : AggregateRoot<Guid>
{
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalAmount { get; private set; }

    public Order(Guid id) : base(id) { }

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product.Id, product.Price, quantity);
        _items.Add(item);
        TotalAmount += item.TotalPrice;

        AddDomainEvent(new OrderItemAddedEvent(Id, product.Id, quantity));
    }
}
```

### Создание Value Object

```csharp
public class Email : ValueObject
{
    public string Value { get; }

    public Email(string value)
    {
        Value = SetCharField("email.field", value, 5, 255);
        
        if (!IsValidEmail(value))
            throw new DomainValidationFieldException("email.field", "valid email format");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private static bool IsValidEmail(string email)
    {
        // валидация email
        return true;
    }
}
```

### Обработка исключений
```csharp
try
{
    var user = new User(Guid.NewGuid(), "", new Email("invalid-email"));
}
catch (DomainRequiredFieldException ex)
{
    // Обработка обязательного поля
    Console.WriteLine($"Field {ex.FieldName} is required");
}
catch (DomainValidationFieldException ex)
{
    // Обработка невалидного поля
    Console.WriteLine($"Field {ex.FieldName} must have {ex.MustHave}");
}
```

## Особенности
- Типобезопасность - строгая типизация для идентификаторов и агрегатов

- Иммутабельность - защита внутреннего состояния сущностей

- Доменные события - встроенная поддержка событийной модели

- Локализация - коды ошибок для поддержки многоязычности

- Валидация - встроенные методы валидации в ValueObject

- Async поддержка - асинхронные операции в репозиториях

## Добавьте проект как зависимость в ваш solution или установите как NuGet пакет (если опубликован).

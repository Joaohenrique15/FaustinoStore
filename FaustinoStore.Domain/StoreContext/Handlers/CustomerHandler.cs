using System;
using FaustinoStore.Domain.StoreContext.CustomerCommands.Inputs;
using FaustinoStore.Domain.StoreContext.Entities;
using FaustinoStore.Domain.StoreContext.Repositories;
using FaustinoStore.Domain.StoreContext.Services;
using FaustinoStore.Domain.StoreContext.ValueObjects;
using FaustinoStore.Shared.Commands;
using FluentValidator;

namespace FaustinoStore.Domain.StoreContext.Handlers
{
  public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
  {
    private readonly ICustomerRepository _repository;
    private readonly IEmailService _emailService;

    public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }

    public ICommandResult Handle(CreateCustomerCommand command)
    {
      // Verificar se o CPF já existe na base
      if (_repository.CheckDocument(command.Document))
        AddNotification("Document", "Este CPF já está em uso");

      // Verificar se o E-mail já existe na base
      if (_repository.CheckEmail(command.Email))
        AddNotification("Email", "Este E-mail já está em uso");

      // Criar os VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);

      // Criar a entidade
      var customer = new Customer(name, document, email, command.Phone);

      // Validar entidades e VOs
      AddNotifications(name.Notifications);
      AddNotifications(document.Notifications);
      AddNotifications(email.Notifications);
      AddNotifications(customer.Notifications);

      // Persistir o cliente
      _repository.Save(customer);

      // Enviar um E-mail de boas vindas
      _emailService.Send(email.Address,"joao.henrique_15@hotmail.com","Bem vindo", "Seja bem vindo ao Faustino Store!");

      // Retornar o resultado para tela
      return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}
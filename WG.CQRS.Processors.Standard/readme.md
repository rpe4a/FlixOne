CQRS pattern realization.
Provides realization of interfaces from WG.CQRS.Base.Standard package.

Usage:

Install SimpleInjector.Integration.AspNetCore.Mvc.Core package

Sample:
```csharp
public class TestCommand : ICommand
{
    public Guid Test { get; set; }
}

public class TestCommand2 : TestCommand
{
}

public class TestCommand2Handler : ICommandHandler<TestCommand2>
{
    public Task HandleAsync(TestCommand2 command)
    {
        return Task.CompletedTask;
    }
}
```

Decorator works for all commands inhereted from TestCommand

```csharp
public class TestCommandDecorator<TCommand> : CommandDecorator<TCommand> where TCommand : TestCommand
{
    public TestCommandDecorator(ICommandHandler<TCommand> decoratee) : base(decoratee)
    {
    }

    protected override Task BeforeHandleAsync(TCommand command)
    {
        command.Test = Guid.NewGuid();
        return Task.CompletedTask;
    }
}
```

Registaration in Startup.cs

```csharp
public class Startup
{
    private Container container = new Container();
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        container.Register<ICommandHandler<TestCommand2>, TestCommand2Handler>();

        container.Register<ICommandProcessor, CommandProcessor>();
        container.Register<IQueryProcessor, QueryProcessor>();

        container.RegisterDecorator(typeof(ICommandHandler<>), typeof(TestCommandDecorator<>));

		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
        services.EnableSimpleInjectorCrossWiring(container);
        services.UseSimpleInjectorAspNetRequestScoping(container);

        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseMvc();


        // Add application presentation components:
        container.RegisterMvcControllers(app);

        // Allow Simple Injector to resolve services from ASP.NET Core.
        container.AutoCrossWireAspNetComponents(app);

        // Verify Simple Injector configuration
        container.Verify();
    }
}
```

How to use in controller:

```csharp
public class ValuesController : ControllerBase
{
    private readonly ICommandProcessor _commandProcessor;
    private readonly IQueryProcessor _queryProccessor;
    public ValuesController(ICommandProcessor commandProcessor, IQueryProcessor queryProccessor)
    {
        _commandProcessor = commandProcessor;
        _queryProccessor = queryProccessor;
    }

    [HttpPost]
    public void Test()
    {
        _commandProcessor.Process(new TestCommand2());
    }
}
```

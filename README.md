# <p><img src="iconMt.png" width="64px" height="64px" align="middle" /> Mt Core</p>

Набор универсальных утилит, расширений используемых в проектах Mt-Relay.

## [История изменения](CHANGELOG.md)

## Покрытие кода тестами

Перед первым запуском `.test.sh`, для просмотра покрытия кода тестами проверьте наличие `dotnet-reportgenerator-globaltool` выполнив команду:

```console
dotnet tool list --global
```

В перечне пакетов должен присутствовать:

```console
Идентификатор пакета                   Версия      Команды
------------------------------------------------------------------
dotnet-reportgenerator-globaltool      5.1.19      reportgenerator
```

При его отсутствии необходимо выполнить команду:

```console
dotnet tool install -g dotnet-reportgenerator-globaltool
```

## Основной функционал

| Компонент                  | Описание                                               |
|----------------------------|--------------------------------------------------------|
| [Mt.Entities.Abstractions] | Абстракции сущностей используемых в Мt-Relay           |
| [Mt.Utilities]             | Универсальные утилиты используемые в проектах Mt-Relay |

[Mt.Entities.Abstractions]: src/Mt.Entities.Abstractions/README.md
[Mt.Utilities]: src/Mt.Utilities/README.md
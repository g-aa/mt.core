# Mt Core

Набор универсальных утилит, расширений используемых в проектах Mt-Relay.

## Покрытие кода тестами

- Перед первым запуском `.test.sh`, для просмотра покрытия кода тестами проверьте наличие `dotnet-reportgenerator-globaltool` выполнив команду:
  ```console
  dotnet tool list --global
  ```

- В перечне пакетов должен присутствовать:
  ```console
  Идентификатор пакета                   Версия      Команды
  ------------------------------------------------------------------
  dotnet-reportgenerator-globaltool      5.1.19      reportgenerator
  ```

- При его отсутствии необходимо выполнить команду:
  ```console
  dotnet tool install -g dotnet-reportgenerator-globaltool
  ```

## Основной функционал

| Компонент                  | Описание                                               |
|----------------------------|--------------------------------------------------------|
| [Mt.Entities.Abstractions] | Абстракции сущностей                                   |
| [Mt.FluentValidation]      | Шаблонов валидации на основе пакета `FluentValidation` |
| [Mt.Results]               | Стандартные ответы результатов операций                |
| [Mt.Utilities]             | Универсальные утилиты                                  |

[Mt.Entities.Abstractions]: src/Mt.Entities.Abstractions/README.md
[Mt.FluentValidation]: src/Mt.FluentValidation/README.md
[Mt.Results]: src/Mt.Results/README.md
[Mt.Utilities]: src/Mt.Utilities/README.md
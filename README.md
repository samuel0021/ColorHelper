# Color Helper

Color Helper é um color picker desktop feito em C# WinForms.  
O aplicativo permite escolher cores pelo espectro HSV, editar valores ARGB e copiar o código HEX, além de ter um modo conta‑gotas para capturar a cor de qualquer pixel da tela.

## Como executar

1. Baixe a última versão aqui: <br>

➡️ [ColorHelper v1.0.0](https://github.com/samuel0021/ColorHelper/releases/download/v1.0.0/ColorHelper-1.0.0-win-x64.zip)

2. Extraia os arquivos da pasta.  
3. Execute o arquivo ColorHelper.exe.

## Funcionalidades

- **Espectro de cores (HSV)**  
  - Geração de um gradiente horizontal em HSV usando `Bitmap` e conversão `FromHsv`.  
  - Seleção de cor clicando ou arrastando sobre o `PictureBox`, com bloqueio do mouse dentro da área de seleção.

- **Conta‑gotas de tela inteira**  
  - Modo “Pick Screen Color” para ler a cor sob o cursor em qualquer ponto da tela usando `CopyFromScreen`.  
  - Atualização em tempo real enquanto o botão esquerdo do mouse está pressionado.

- **Edição por ARGB e HEX**  
  - Campos para **Alpha**, **Red**, **Green** e **Blue**, com recalculo automático da cor ao alterar qualquer canal.  
  - Campo **HEX** suportando os formatos `#RRGGBB` e `#AARRGGBB`, com conversão manual entre decimal e hexadecimal.  
  - Botão para copiar o HEX atual para a área de transferência.

- **Controle de opacidade**  
  - `TrackBar` para ajustar o canal **Alpha** (0–255), sincronizado com o campo de texto e com a cor de preview.

## Detalhes de implementação

- Projeto em **C# .NET (WinForms)**.  
- Classe auxiliar `ColorPickerHelper` responsável por:
  - Geração do gradiente HSV (`GerarGradiente` + `FromHsv`).  
  - Captura de cor do `PictureBox` (`CaptureColor`) e da tela (`GetScreenColorAt`).  
  - Aplicação dos valores nos controles (`ApplyColorToControls`).  
  - Conversão de e para HEX (`HexToColor`, `#AARRGGBB`).

- A `Form1` cuida:
  - Dos eventos de mouse do espectro de cores e do modo conta‑gotas.  
  - Da sincronização entre ARGB, HEX e `TrackBar` de opacidade.  
  - De pequenos utilitários como copiar HEX para o clipboard.

## Próximas melhorias (ideias)

- Refatorar para uma arquitetura mais desacoplada (separando UI e lógica de domínio).  
- Adicionar prévias de paleta e histórico de cores.  
- Implementar suporte a outros espaços de cor (HSL, CMYK) e exportação de paletas.

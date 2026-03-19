# RSII — Desktop & Mobile (Flutter) — T25

Monorepo for **Razvoj softvera II (RS II)** coursework: a full-stack **eCommerce** sample with an **ASP.NET Core** Web API, **Entity Framework** data layer, and **Flutter** clients (**desktop** and **mobile**).

---

## Repository structure

| Path | Purpose |
|------|---------|
| [`Template/`](Template/) | Baseline solution: `eCommerce.sln`, `eCommerce.WebAPI`, `eCommerce.Services`, `eCommerce.Model`, Flutter apps under `UI/ecommerce_desktop` and `UI/ecommerce_mobile`. |
| [`rsII_exam_template_2024_25-main/`](rsII_exam_template_2024_25-main/) | Official exam template (same stack pattern as `Template/`). |
| [`Workshops/`](Workshops/) | Numbered workshop / *ispitni* exercise folders (e.g. cart, favorites, discount). Each contains its own `eCommerce.sln` and copies of the stack. |
| [`Ispitni zadaci/`](Ispitni%20zadaci/) | Exam briefs (PDF), screenshots, and related assets. |
| [`Prijave seminarskih/`](Prijave%20seminarskih/) | Seminar topic submissions (documents). |
| [`Projects/`](Projects/) | Project screenshots and reference images. |
| [`Commands/`](Commands/) | Short command cheat sheet for migrations and Dart code generation. |
| [`.github/`](.github/) | GitHub metadata (workflows, etc., if present). |

```text
Flutter Repos/
├── Template/                 # Start here for the canonical project
├── rsII_exam_template_2024_25-main/
├── Workshops/
│   ├── 1. ISPITNI REWARD RULE/
│   ├── 2. ISPITNI CART/
│   ├── 3. ISPITNI FAVORITI/
│   ├── 4. ISPITNI DISCOUNT/
│   └── 5. ISPITNI DISCOUNT-VIDEO/
├── Ispitni zadaci/
├── Prijave seminarskih/
├── Projects/
├── Commands/
└── RSII_Upute_za_predaju_seminarskog_rada_2024_25.pdf
```

---

## Tech stack

- **Backend:** .NET Web API, EF Core migrations (see `Commands/Commands.txt`).
- **Clients:** Flutter (`ecommerce_desktop`, `ecommerce_mobile`) — SDK constraint in template is Dart **≥ 3.4.4 \< 4.0.0** (check each `pubspec.yaml` if versions differ per folder).

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version compatible with the solution).
- [Flutter](https://docs.flutter.dev/get-started/install) with desktop tooling enabled where needed.
- Database configured as in each project’s `appsettings.json` (SQL Server / LocalDB is typical for this course template).

---

## Quick start (using `Template/`)

1. Open `Template/eCommerce.sln` in Visual Studio / Rider, or build from the CLI:

   ```bash
   cd Template/eCommerce
   dotnet build
   ```

2. Apply EF migrations (from the folder that contains `eCommerce.WebAPI` and `eCommerce.Services` — paths match your chosen copy, e.g. `Template/eCommerce`):

   ```bash
   dotnet ef migrations add init --project .\eCommerce.Services --startup-project .\eCommerce.WebAPI
   ```

3. Run the API (`eCommerce.WebAPI`), then start a Flutter app:

   ```bash
   cd Template/UI/ecommerce_mobile   # or ecommerce_desktop
   flutter pub get
   flutter run
   ```

4. Regenerate Dart `*.g.dart` files when models use `json_serializable` / similar:

   ```bash
   dart run build_runner build
   ```

Exact folder names may differ slightly between `Template`, exam template, and `Workshops` copies — always open the `eCommerce.sln` inside the folder you are working in.

---

## Which folder should I use?

- **Course baseline / new work:** `Template/`.
- **Exam submission starting point:** `rsII_exam_template_2024_25-main/`.
- **Specific lab or past *ispitni* variant:** matching subfolder under `Workshops/`.

---

## Documentation

- Seminar submission guidelines: **`RSII_Upute_za_predaju_seminarskog_rada_2024_25.pdf`** (repository root).
- Exam tasks and references: **`Ispitni zadaci/`**.

---

## License / academic use

Use according to your institution’s rules for RS II materials. If this repo is public, add a `LICENSE` file when your course allows it.

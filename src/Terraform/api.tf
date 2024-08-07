resource "azurerm_service_plan" "appserviceplan" {
  name                = "asp-omni-opme-api-eastus"
  resource_group_name = azurerm_resource_group.rg_app.name
  location            = azurerm_resource_group.rg_app.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "appservice" {
  name                = "appsvc-omni-opme-eastus"
  resource_group_name = azurerm_resource_group.rg_app.name
  location            = azurerm_service_plan.appserviceplan.location
  service_plan_id     = azurerm_service_plan.appserviceplan.id

  site_config {
    always_on        = false
    app_command_line = "dotnet Omini.Opme.Api.dll"

    application_stack {
      dotnet_version = "8.0"
    }

    cors {
      allowed_origins = ["*"]
    }
  }

  app_settings = {
    "Auth0__Authority"         = "https://dev-amo5k5tptruva3yj.us.auth0.com"
    "Auth0__Audience"          = "https://omini-opme-api-dev.endpoint"
    "DOTNET_ENVIRONMENT"       = "Development"
  }

  lifecycle {
    ignore_changes = [
      app_settings["WEBSITE_ENABLE_SYNC_UPDATE_SITE"],
      connection_string
    ]
  }
}

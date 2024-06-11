terraform {
  backend "azurerm" {
    resource_group_name  = "rg-omni-opme-terraform-eastus-dev"
    storage_account_name = "stomniopmetfstateeusdev"
    container_name       = "terraform-state"
    key                  = "terraform.tfstate"
  }

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.83.0"
    }
  }

  required_version = ">= 1.1.0"
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg_app" {
  name     = local.common_settings.resource_group
  location = local.common_settings.location
}

resource "azurerm_resource_group" "rg_b2c" {
  name     = local.b2c_settings.resource_group
  location = local.b2c_settings.location
}

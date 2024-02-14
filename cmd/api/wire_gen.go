// Code generated by Wire. DO NOT EDIT.

//go:generate go run github.com/google/wire/cmd/wire
//go:build !wireinject
// +build !wireinject

package api

import (
	"github.com/go-chi/chi/v5"
	"github.com/google/wire"
	"github.com/omini-services/omini-opme-be/cmd/api/handlers"
	"github.com/omini-services/omini-opme-be/internal/domain"
	"github.com/omini-services/omini-opme-be/internal/repository"
	"github.com/omini-services/omini-opme-be/internal/usecase"
	"gorm.io/gorm"
)

// Injectors from wire.go:

func NewApiHandler(r chi.Router) *handlers.ApiHandler {
	apiHandler := handlers.NewApiHandler(r)
	return apiHandler
}

func NewItemHandler(r chi.Router, db *gorm.DB) *handlers.ItemHandler {
	itemRepository := repository.NewItemRepository(db)
	itemUsecase := usecase.NewItemUsecase(itemRepository)
	itemHandler := handlers.NewItemHandler(r, itemUsecase)
	return itemHandler
}

func NewInvoiceHandler(r chi.Router, db *gorm.DB) *handlers.InvoiceHandler {
	invoiceRepository := repository.NewInvoiceRepository(db)
	invoiceUsecase := usecase.NewInvoiceUsecase(invoiceRepository)
	invoiceHandler := handlers.NewInvoiceHandler(r, invoiceUsecase)
	return invoiceHandler
}

// wire.go:

var (
	setItemRepositoryDependency = wire.NewSet(repository.NewItemRepository, wire.Bind(new(domain.ItemRepository), new(*repository.ItemRepository)))

	setItemUsecaseDependency = wire.NewSet(usecase.NewItemUsecase, wire.Bind(new(domain.ItemUsecase), new(*usecase.ItemUsecase)))
)

var (
	setInvoiceRepositoryDependency = wire.NewSet(repository.NewInvoiceRepository, wire.Bind(new(domain.InvoiceRepository), new(*repository.InvoiceRepository)))

	setInvoiceUsecaseDependency = wire.NewSet(usecase.NewInvoiceUsecase, wire.Bind(new(domain.InvoiceUsecase), new(*usecase.InvoiceUsecase)))
)

package handler

import (
	"encoding/json"
	"errors"
	"net/http"

	"github.com/omini-services/omini-opme-be/internal/entity"
	"github.com/omini-services/omini-opme-be/internal/infra/web/response"
	"github.com/omini-services/omini-opme-be/internal/usecase"
)

type WebItemHandler struct {
	ItemRepository entity.ItemRepositoryInterface
}

func NewWebItemHandler(
	ItemRepository entity.ItemRepositoryInterface,
) *WebItemHandler {
	return &WebItemHandler{
		ItemRepository: ItemRepository,
	}
}

func (h *WebItemHandler) GetItems(w http.ResponseWriter, r *http.Request) {
	var dto usecase.GetItemsInputDTO

	// err := json.NewDecoder(r.Body).Decode(&dto)
	// if err != nil {
	// 	http.Error(w, err.Error(), http.StatusBadRequest)
	// 	return
	// }
	getItems := usecase.NewGetItemsUseCase(h.ItemRepository)
	output, err := getItems.Execute(dto)
	if err != nil {
		response.JsonFail(w, []error{errors.New("could not get items")}, http.StatusInternalServerError)
		return
	}

	response.JsonSuccess(w, output, http.StatusOK)
}

func (h *WebItemHandler) CreateItem(w http.ResponseWriter, r *http.Request) {
	var dto usecase.CreateItemInputDTO
	decodeError := json.NewDecoder(r.Body).Decode(&dto)
	if decodeError != nil {
		http.Error(w, decodeError.Error(), http.StatusBadRequest)
		return
	}

	createOrder := usecase.NewCreateItemUseCase(h.ItemRepository)
	output, err := createOrder.Execute(dto)

	if err != nil {
		response.JsonFail(w, err, http.StatusBadRequest)
		return
	}

	response.JsonSuccess(w, output, http.StatusOK)
}

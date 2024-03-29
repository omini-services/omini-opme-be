package handlers

import (
	"encoding/json"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/omini-services/omini-opme-be/configs"
)

type ApiHandler struct {
}

func NewApiHandler(r chi.Router) *ApiHandler {
	handler := &ApiHandler{}

	r.Get("/health", handler.Health)

	return handler
}

// swagger:route DELETE /admin/company/{id} admin deleteCompany
// Delete company
//
// security:
// - apiKey: []
// responses:
//
//	401: CommonError
//	200: CommonSuccess
//
// Create handles Delete get company
func (h *ApiHandler) Health(w http.ResponseWriter, r *http.Request) {
	json.NewEncoder(w).Encode(map[string]interface{}{
		"version": configs.GetVersion(),
		"build":   configs.GetBuild(),
	})

	w.WriteHeader(http.StatusOK)
}

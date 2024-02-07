FROM golang:alpine3.19 as builder
ARG API_VERSION

WORKDIR /app
COPY . . 
RUN GOOS=linux CGO_ENABLED=0 go build -ldflags="-w -s -X 'main.version=${API_VERSION}' -X 'main.build=$(date)'" -o server ./cmd/server 
RUN apk add curl
RUN curl --create-dirs -o /etc/ssl/certs/root.crt 'https://cockroachlabs.cloud/clusters/5158009c-768c-4ba7-966e-282e3104f89f/cert'

FROM scratch

WORKDIR /app
COPY --from=builder /app/server .
COPY --from=builder /etc/ssl/certs/root.crt /etc/ssl/certs/

EXPOSE 80
ENTRYPOINT ["/app/server"]
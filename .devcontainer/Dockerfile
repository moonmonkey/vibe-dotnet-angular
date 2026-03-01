# Base image with .NET  10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Install Node.js (LTS)
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash - \
    && apt-get install -y nodejs \
    && apt-get clean -y

# Install bash and other essentials
RUN apt-get update && apt-get install -y git curl unzip vim

# Create non-root user for Codespaces
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

RUN groupadd --gid $USER_GID $USERNAME \
    && useradd -s /bin/bash --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && chown -R $USERNAME:$USERNAME /home/$USERNAME
    
USER $USERNAME
WORKDIR /workspace
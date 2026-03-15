# AgentFlow AI -- Microservices AI Workflow Platform

## Project Goal

Build a resume‑ready learning project demonstrating: - Microservices
architecture - API Gateway - Authentication (JWT) - Angular frontend -
SignalR real‑time communication - Python AI services - AI agent
orchestration workflows

This project mimics enterprise architecture patterns but in a simplified
form for learning and interview preparation.

------------------------------------------------------------------------

# High Level Architecture

Angular Frontend → API Gateway → Microservices

Services: - Auth Service - Agent Service - Workflow Service - AI Service
(Python)

SignalR streams workflow execution results to the UI in real time.

------------------------------------------------------------------------

# Core Features

## Authentication

Users can: - Register - Login - Access protected APIs - Manage workflows

Tech: - ASP.NET Core - JWT authentication - Entity Framework

------------------------------------------------------------------------

# AI Agent Marketplace

Agents are modular plugins users can install.

Example agents: - Summarizer - Task Extractor - Email Generator - Code
Explainer

Agents store metadata: - name - description - endpoint - input schema -
output schema

------------------------------------------------------------------------

# Workflow System

Users create workflows combining agents.

Example:

Input → Summarizer → Task Extractor → Email Generator

Workflow structure:

Workflow - id - name - userId

WorkflowSteps - agentId - order

ExecutionHistory - workflowId - status - result

------------------------------------------------------------------------

# Microservices

## API Gateway

Responsibilities: - Entry point - Routing - Authentication validation

Technology: - ASP.NET Core - YARP reverse proxy

Routes: /auth → auth service /agents → agent service /workflow →
workflow service

------------------------------------------------------------------------

## Auth Service

Endpoints:

POST /register POST /login GET /profile

Database:

Users - Id - Email - PasswordHash - CreatedAt

------------------------------------------------------------------------

## Agent Service

Endpoints:

GET /agents GET /agents/marketplace POST /agents/install

Database:

Agents AgentVersions InstalledAgents

------------------------------------------------------------------------

## Workflow Service

Endpoints:

POST /workflow GET /workflow POST /workflow/run

Handles: - workflow orchestration - execution tracking

------------------------------------------------------------------------

## AI Service (Python)

Technology: FastAPI

Endpoints:

POST /summarize POST /extract-tasks POST /generate-email POST
/explain-code

Responsible for: - AI processing - LLM calls - returning results

------------------------------------------------------------------------

# Real-Time Workflow Execution

Execution flow:

1.  Angular calls workflow run API
2.  Workflow service calls AI service
3.  AI service processes agents sequentially
4.  SignalR streams results back to Angular UI

Example UI output:

Running Workflow ✓ Summarizer completed ✓ Task extractor completed ✓
Email draft completed

------------------------------------------------------------------------

# Angular Frontend

Pages:

/login /dashboard /agents /workflow-builder /workflow-execution

Features: - JWT auth interceptor - workflow builder UI - agent
marketplace - real-time execution updates

------------------------------------------------------------------------

# Database Design

Auth DB: Users

Agent DB: Agents AgentVersions InstalledAgents

Workflow DB: Workflows WorkflowSteps ExecutionHistory ExecutionResults

------------------------------------------------------------------------

# Development Roadmap

## Phase 1

Project setup Architecture structure Git repository

## Phase 2

Auth Service JWT authentication Angular login

## Phase 3

API Gateway

## Phase 4

Agent Service Agent marketplace

## Phase 5

AI Service (Python)

## Phase 6

Workflow Service

## Phase 7

Angular UI

## Phase 8

SignalR streaming

## Phase 9

Execution history and logging

------------------------------------------------------------------------

# Resume Value

This project demonstrates:

-   Microservices architecture
-   API Gateway design
-   AI agent orchestration
-   Real-time systems with SignalR
-   Angular enterprise frontend
-   Python AI integration

Example resume bullet:

"Developed an AI workflow automation platform using Angular, .NET
microservices, and Python AI services. Implemented API Gateway routing,
JWT authentication, real-time SignalR streaming, and a plugin-based AI
agent architecture."

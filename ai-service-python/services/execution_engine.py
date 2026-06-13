from agents.summarizer import execute as summarize
from agents.task_extractor import execute as task_extract
from agents.email_generator import execute as email_generate


class ExecutionEngine:

    registry = {
        "summarizer": summarize,
        "task-extractor": task_extract,
        "email-generator": email_generate
    }

    @classmethod
    def execute(cls, agent_name, payload):

        handler = cls.registry.get(agent_name)

        if not handler:
            raise Exception("Agent not found")

        return handler(payload)
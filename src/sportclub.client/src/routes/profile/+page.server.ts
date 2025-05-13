// +page.server.ts
export const actions = {
	default: async ({ request }) => {
		const data = await request.formData();
		const email = data.get('email');

		// Forward to ASP.NET API
		const res = await fetch('https://api.example.com/send', {
			method: 'POST',
			body: JSON.stringify({ email }),
			headers: { 'Content-Type': 'application/json' }
		});

		if (!res.ok) {
			return fail(400, { error: 'Submission failed' });
		}

		return { success: true };
	}
};

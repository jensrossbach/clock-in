#ClockIn Workflow
This guide shows the ClockIn contribution workflow using GitLab and Git.

##Working with Issues
Issues are used to track the work done inside the ClockIn repository.

###Creating Issues
Every kind of work should usually be documented by an issue. There might be exceptions for very small changes or fixes for which creating issues would mean too much overhead (e.g. you closed an issue and just afterwards detect a problem with your change).

For the usual workflow, if you encounter a bug/defect, have a proposal for an enhancement of the software or any other kind of request, you have to create an issue. Every issue must have a meaningful and understandable title and description. Optionally, they can have a due date. Issues must be tagged with at least one appropriate descriptive label:

- For a software defect, use *bug* or *regression*.
- For an enhancement proposal, use *enhancement*.
- If the issue must be processed with high priority, use *critical*.
- To start a discussion about a certain topic, use *discussion*.
- To ask for support with the software, use *support*.
- For any kind of documentation, use *documentation*.
- For changes which are not visible to end users, use *internals*.

All other labels are reserved for state indication and must not be used when creating issues. Do not set the assignee and milestone attributes, this is also done in a later stage of the workflow (see below).

###Issue based Workflow
The issue based workflow is described step-wise in the next couple of chapters.

####Analysis and Planning
The following steps are usually done by the maintainers of the project.

1. If the issue is accepted and will be worked on, continue with step 4 below.
2. If the issue describes the same (or very similar) topic as already another issue, assign the *duplicate* label, add a comment with a link to the duplicate and close the issue.
3. If the issue should not be accepted for any kind of reason, assign the *rejected* label, add a comment with a rationale for the refusal and close the issue.
4. Assign the issue to a milestone. This step can be omitted if the issue does not affect a future release of the software (e.g. pure documentation outside of the repository, discussion, support).
5. Assign the issue to the responsible person or to yourself.
6. From within the issue, create a merge request with a branch called "clockin-#" with *#* being the number of the issue (example: `clockin-12`). The merge request will automatically be linked with the issue and inherit the labels from the issue. This step can be omitted in case the issue does not affect the repository and as a consequence nothing needs to be merged.
7. In the issue board, drag the issue into the *confirmed* column. This will automatically assign the *confirmed* label to the issue.

####Working on the Issue
The following steps are done by the developers and the maintainers of the project.

1. In the issue board, drag the issue from the *confirmed* column into the *working* column. This will automatically remove the *confirmed* label and assign the *working* label to the issue.
2. Do the work which is needed in order to resolve the issue.
3. If the repository is affected by the issue, continue with step 5 below.
4. If the work does not change the contents of the repository (e.g. documentation in the GitLab wiki), close the issue.
5. Stage and commit the changes in your local git repository.
6. Push your commits to the remote branch of the appropriate merge request, e.g.:
`git push origin HEAD:clockin-12`
7. When done with the work necessary to resolve the issue, remove the WiP (work in progress) status of the merge request. This indicates to the maintainers that the changes are ready for review and can finally be merged.

####Completion
The following steps are usually done by the maintainers of the project.

1. If the issue does not include a merge request, check the changes and continue with step 7.
2. Review the changes of the merge request being ready.
3. If a fast-foward merge is not possible, ask the change responsible (for instance by adding a comment to the merge request) to rebase the commits and continue with the next step after this has been done.
4. Activate the options to automatically delete the source branch after merging and activate squashing of the commits.
5. Press the merge button.
6. In the issue, remove the *working* label and add the *solved* label.

##Releasing the Software
When a milestone has been completed, the software has to be released. For this purpose, a final merge request (without issue) must be created. The merge request should be tagged with the *release* label und assigned to the milestone. The corresponding branch should have the name *release-major.minor* (using the major and minor version part of the software to be released).

In context of this merge request, the following changes need to be done:

- In the file AssemblyInfo.cs, the major and minor part of the version must be adapted to the release version.
- In the file README.md, the major and minor part of the version must be adapted to the release version.
- The binaries must be built in release configuration. Check the complete version via the properties dialog of the release executable. Do not build the software another time as this would change the build and patch part of the version.
- In the file History.txt, the release notes of the release must be added using the following template.
```
v<Major.Minor.Build.Patch> (<YYYY-MM-DD>)
-----------------------------------------

Added:   Added functionality
Changed: Changed functionality
Fixed:   Solved defect
```
After these changes have been committed, pushed and merged, a release tag must be created and assigned to the commit with above changes. The tag should have the name *release-major.minor* (i.e. same as the branch name above) and the following description:
```
Version <Major.Minor.Build.Patch> from <YYYY-MM-DD>
- [added] Added functionality
- [changed] Changed functionality
- [fixed] Solved defect
```
Please also have a look to the former entries in the file History.txt and the former release tags in the repository.

Finally the milestone has to be closed.
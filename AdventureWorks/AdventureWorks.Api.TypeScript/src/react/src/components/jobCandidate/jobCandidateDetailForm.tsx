import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import JobCandidateMapper from './jobCandidateMapper';
import JobCandidateViewModel from './jobCandidateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface JobCandidateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface JobCandidateDetailComponentState {
  model?: JobCandidateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class JobCandidateDetailComponent extends React.Component<
  JobCandidateDetailComponentProps,
  JobCandidateDetailComponentState
> {
  state = {
    model: new JobCandidateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.JobCandidates + '/edit/' + this.state.model!.jobCandidateID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.JobCandidateClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.JobCandidates +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new JobCandidateMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Business Entity I D</h3>
              <p>
                {String(
                  this.state.model!.businessEntityIDNavigation &&
                    this.state.model!.businessEntityIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Resume</h3>
              <p>{String(this.state.model!.resume)}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedJobCandidateDetailComponent = Form.create({
  name: 'JobCandidate Detail',
})(JobCandidateDetailComponent);


/*<Codenesium>
    <Hash>c7ef863c48aa94d844c289261b35897a</Hash>
</Codenesium>*/
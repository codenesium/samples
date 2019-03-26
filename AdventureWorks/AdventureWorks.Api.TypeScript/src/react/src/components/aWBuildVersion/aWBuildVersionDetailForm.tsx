import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface AWBuildVersionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AWBuildVersionDetailComponentState {
  model?: AWBuildVersionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AWBuildVersionDetailComponent extends React.Component<
  AWBuildVersionDetailComponentProps,
  AWBuildVersionDetailComponentState
> {
  state = {
    model: new AWBuildVersionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.AWBuildVersions +
        '/edit/' +
        this.state.model!.systemInformationID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.AWBuildVersionClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.AWBuildVersions +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new AWBuildVersionMapper();

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
            <div>
              <h3>Database Version</h3>
              <p>{String(this.state.model!.database_Version)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Version Date</h3>
              <p>{String(this.state.model!.versionDate)}</p>
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

export const WrappedAWBuildVersionDetailComponent = Form.create({
  name: 'AWBuildVersion Detail',
})(AWBuildVersionDetailComponent);


/*<Codenesium>
    <Hash>50aa71fa7225d0f69b64107a7cef9f69</Hash>
</Codenesium>*/
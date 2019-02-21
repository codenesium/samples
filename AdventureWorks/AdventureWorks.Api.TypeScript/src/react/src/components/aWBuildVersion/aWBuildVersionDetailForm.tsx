import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AWBuildVersionMapper from './aWBuildVersionMapper';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.AWBuildVersions +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AWBuildVersionClientResponseModel;

          console.log(response);

          let mapper = new AWBuildVersionMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>SystemInformationID</h3>
              <p>{String(this.state.model!.systemInformationID)}</p>
            </div>
            <div>
              <h3>VersionDate</h3>
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
    <Hash>46d9ed30d30b6a079152c527db80933f</Hash>
</Codenesium>*/
import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ColumnSameAsFKTableMapper from './columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from './columnSameAsFKTableViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface ColumnSameAsFKTableDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ColumnSameAsFKTableDetailComponentState {
  model?: ColumnSameAsFKTableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ColumnSameAsFKTableDetailComponent extends React.Component<
  ColumnSameAsFKTableDetailComponentProps,
  ColumnSameAsFKTableDetailComponentState
> {
  state = {
    model: new ColumnSameAsFKTableViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ColumnSameAsFKTables + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ColumnSameAsFKTableClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ColumnSameAsFKTables +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ColumnSameAsFKTableMapper();

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
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Person</h3>
              <p>
                {String(
                  this.state.model!.personNavigation &&
                    this.state.model!.personNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>PersonId</h3>
              <p>
                {String(
                  this.state.model!.personIdNavigation &&
                    this.state.model!.personIdNavigation!.toDisplay()
                )}
              </p>
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

export const WrappedColumnSameAsFKTableDetailComponent = Form.create({
  name: 'ColumnSameAsFKTable Detail',
})(ColumnSameAsFKTableDetailComponent);


/*<Codenesium>
    <Hash>bb597a5476862deed36a0f35362bba2b</Hash>
</Codenesium>*/
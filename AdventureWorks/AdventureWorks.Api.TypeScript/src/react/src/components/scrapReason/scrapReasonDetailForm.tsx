import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ScrapReasonMapper from './scrapReasonMapper';
import ScrapReasonViewModel from './scrapReasonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { WorkOrderTableComponent } from '../shared/workOrderTable';

interface ScrapReasonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ScrapReasonDetailComponentState {
  model?: ScrapReasonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ScrapReasonDetailComponent extends React.Component<
  ScrapReasonDetailComponentProps,
  ScrapReasonDetailComponentState
> {
  state = {
    model: new ScrapReasonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.ScrapReasons + '/edit/' + this.state.model!.scrapReasonID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.ScrapReasonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.ScrapReasons +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new ScrapReasonMapper();

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
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>WorkOrders</h3>
            <WorkOrderTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.ScrapReasons +
                '/' +
                this.state.model!.scrapReasonID +
                '/' +
                ApiRoutes.WorkOrders
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedScrapReasonDetailComponent = Form.create({
  name: 'ScrapReason Detail',
})(ScrapReasonDetailComponent);


/*<Codenesium>
    <Hash>9b68e9db6da868b7b9babb30230c5dca</Hash>
</Codenesium>*/
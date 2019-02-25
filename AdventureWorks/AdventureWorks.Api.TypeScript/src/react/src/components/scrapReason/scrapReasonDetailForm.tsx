import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ScrapReasonMapper from './scrapReasonMapper';
import ScrapReasonViewModel from './scrapReasonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.ScrapReasons +
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
          let response = resp.data as Api.ScrapReasonClientResponseModel;

          console.log(response);

          let mapper = new ScrapReasonMapper();

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
            loaded: true,
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
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
            <div>
              <h3>ScrapReasonID</h3>
              <p>{String(this.state.model!.scrapReasonID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>WorkOrders</h3>
            <WorkOrderTableComponent
              workOrderID={this.state.model!.workOrderID}
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
    <Hash>e616c73fd77455a3060091df3345f948</Hash>
</Codenesium>*/
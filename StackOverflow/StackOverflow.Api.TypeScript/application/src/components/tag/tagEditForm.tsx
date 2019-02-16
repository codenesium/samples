import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import TagViewModel from './tagViewModel';
import TagMapper from './tagMapper';

interface Props {
  model?: TagViewModel;
}

const TagEditDisplay = (props: FormikProps<TagViewModel>) => {
  let status = props.status as UpdateResponse<Api.TagClientRequestModel>;

  let errorsForField = (name: string): string => {
    let response = '';
    if (
      props.touched[name as keyof TagViewModel] &&
      props.errors[name as keyof TagViewModel]
    ) {
      response += props.errors[name as keyof TagViewModel];
    }

    if (
      status &&
      status.validationErrors &&
      status.validationErrors.find(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )
    ) {
      response += status.validationErrors.filter(
        f => f.propertyName.toLowerCase() == name.toLowerCase()
      )[0].errorMessage;
    }

    return response;
  };

  let errorExistForField = (name: string): boolean => {
    return errorsForField(name) != '';
  };

  return (
    <form onSubmit={props.handleSubmit} role="form">
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('count')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          Count
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="count"
            className={
              errorExistForField('count')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('count') && (
            <small className="text-danger">{errorsForField('count')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('excerptPostId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          ExcerptPostId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="excerptPostId"
            className={
              errorExistForField('excerptPostId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('excerptPostId') && (
            <small className="text-danger">
              {errorsForField('excerptPostId')}
            </small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('tagName')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          TagName
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="tagName"
            className={
              errorExistForField('tagName')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('tagName') && (
            <small className="text-danger">{errorsForField('tagName')}</small>
          )}
        </div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="name"
          className={
            errorExistForField('wikiPostId')
              ? 'col-sm-2 col-form-label is-invalid'
              : 'col-sm-2 col-form-label'
          }
        >
          WikiPostId
        </label>
        <div className="col-sm-12">
          <Field
            type="textbox"
            name="wikiPostId"
            className={
              errorExistForField('wikiPostId')
                ? 'form-control is-invalid'
                : 'form-control'
            }
          />
          {errorExistForField('wikiPostId') && (
            <small className="text-danger">
              {errorsForField('wikiPostId')}
            </small>
          )}
        </div>
      </div>

      <button type="submit" className="btn btn-primary" disabled={false}>
        Submit
      </button>
      <br />
      <br />
      {status && status.success ? (
        <div className="alert alert-success">Success</div>
      ) : null}

      {status && !status.success ? (
        <div className="alert alert-danger">Error occurred</div>
      ) : null}
    </form>
  );
};

const TagEdit = withFormik<Props, TagViewModel>({
  mapPropsToValues: props => {
    let response = new TagViewModel();
    response.setProperties(
      props.model!.count,
      props.model!.excerptPostId,
      props.model!.id,
      props.model!.tagName,
      props.model!.wikiPostId
    );
    return response;
  },

  // Custom sync validation
  validate: values => {
    let errors: FormikErrors<TagViewModel> = {};

    if (values.count == 0) {
      errors.count = 'Required';
    }
    if (values.excerptPostId == 0) {
      errors.excerptPostId = 'Required';
    }
    if (values.id == 0) {
      errors.id = 'Required';
    }
    if (values.tagName == '') {
      errors.tagName = 'Required';
    }
    if (values.wikiPostId == 0) {
      errors.wikiPostId = 'Required';
    }

    return errors;
  },
  handleSubmit: (values, actions) => {
    actions.setStatus(undefined);

    let mapper = new TagMapper();

    axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Tags + '/' + values.id,

        mapper.mapViewModelToApiRequest(values),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as UpdateResponse<Api.TagClientRequestModel>;
          actions.setStatus(response);
          console.log(response);
        },
        error => {
          console.log(error);
          actions.setStatus('Error from API');
        }
      )
      .then(response => {
        // cleanup
      });
  },

  displayName: 'TagEdit',
})(TagEditDisplay);

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface TagEditComponentProps {
  match: IMatch;
}

interface TagEditComponentState {
  model?: TagViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class TagEditComponent extends React.Component<
  TagEditComponentProps,
  TagEditComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Tags +
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
          let response = resp.data as Api.TagClientResponseModel;

          console.log(response);

          let mapper = new TagMapper();

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
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return <TagEdit model={this.state.model} />;
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>a5fbd0e166e066c74d09ace2db20bab1</Hash>
</Codenesium>*/